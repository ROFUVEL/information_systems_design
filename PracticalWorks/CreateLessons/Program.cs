using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CreateLessons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Lesson> lessons = new List<Lesson>();

            Console.WriteLine("Выберите источник данных:");
            Console.WriteLine("1 - Ввод вручную");
            Console.WriteLine("2 - Из файла input.txt");
            string choice = Console.ReadLine();

            string inputAll = "";

            if (choice == "1")
            {
                Console.WriteLine("Введите объекты одной строкой, разделяя их точкой с запятой ';'");
                Console.WriteLine("Пример: 2025.10.06 10:00 \"Иван\" \"Zoom\" true; 2025.10.07 12:30 \"Мария\" \"Группа 101\" 20; 2025.10.08 09:00 \"Анна\"");
                inputAll = Console.ReadLine();
            }
            else if (choice == "2")
            {
                if (File.Exists("input.txt"))
                {
                    inputAll = File.ReadAllText("input.txt");
                    Console.WriteLine("Данные считаны из файла.");
                }
                else
                {
                    Console.WriteLine("Файл input.txt не найден!");
                    return;
                }
            }

            string[] objectStrings = inputAll.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string obj in objectStrings)
            {
                Lesson parsed = ParseAuto(obj.Trim());
                if (parsed != null)
                    lessons.Add(parsed);
            }

            Console.WriteLine("\n=== Список всех занятий ===");
            foreach (Lesson lesson in lessons)
            {
                Console.WriteLine(lesson);
            }
        }

        static Lesson ParseAuto(string input)
        {
            try
            {
                string[] parts = input.Split('"');
                string[] dateTimeParts = parts[0].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                DateTime date = DateTime.Parse(dateTimeParts[0]);
                TimeSpan time = TimeSpan.Parse(dateTimeParts[1]);
                string teacher = parts[1];

                if (parts.Length == 3)
                {
                    return new Lesson
                    {
                        DateLesson = date,
                        TimeLesson = time,
                        TeacherName = teacher
                    };
                }
                else if (parts.Length == 5)
                {
                    string nextQuoted = parts[3];

                    if (parts[4].Trim().StartsWith("true") || parts[4].Trim().StartsWith("false"))
                    {
                        bool isRec = bool.Parse(parts[4].Trim());
                        return new OnlineLesson
                        {
                            DateLesson = date,
                            TimeLesson = time,
                            TeacherName = teacher,
                            Platform = nextQuoted,
                            IsRecorded = isRec
                        };
                    }
                    else
                    {
                        int count = int.Parse(parts[4].Trim());
                        return new GroupLesson
                        {
                            DateLesson = date,
                            TimeLesson = time,
                            TeacherName = teacher,
                            GroupName = nextQuoted,
                            StudentsCount = count
                        };
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке строки: {input}");
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
