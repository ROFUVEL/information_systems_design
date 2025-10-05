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
            List<Lesson> allLessons = new List<Lesson>();

            string inputData = GetInputData();
            if (string.IsNullOrWhiteSpace(inputData))
            {
                Console.WriteLine("Нет данных для обработки.");
                return;
            }

            allLessons = LessonParser.ParseMultiple(inputData);

            Console.WriteLine("\nСписок всех занятий:");
            PrintLessons(allLessons);
        }

        static string GetInputData()
        {
            Console.WriteLine("Выберите источник данных:");
            Console.WriteLine("1 - Ввести вручную");
            Console.WriteLine("2 - Считать из файла input.txt");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Введите объекты, разделяя их точкой с запятой ';'");
                Console.WriteLine("Пример: 2025.10.06 10:00 \"Иван\" \"Zoom\" true; 2025.10.07 12:30 \"Мария\" \"Группа 101\" 20; 2025.10.08 09:00 \"Анна\"");
                return Console.ReadLine();
            }
            else if (choice == "2")
            {
                return FileHandler.ReadFile("input.txt");
            }

            return string.Empty;
        }

        static void PrintLessons(IEnumerable<Lesson> lessons)
        {
            foreach (Lesson lesson in lessons)
            {
                Console.WriteLine(lesson);
            }
        }
    }
}
