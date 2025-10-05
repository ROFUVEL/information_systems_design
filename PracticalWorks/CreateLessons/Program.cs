using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateLessons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Lesson> listLessons = new List<Lesson>();

            while (true)
            {
                Console.WriteLine("Какой тип объекта хотите добавить?");
                Console.WriteLine("1 - Обычное занятие");
                Console.WriteLine("2 - Онлайн занятие");
                Console.WriteLine("3 - Групповое занятие");
                Console.WriteLine("0 - закончить ввод");

                string inputType = Console.ReadLine();
                if (inputType == "0")
                    break;

                Console.WriteLine("Введите данные...");

                if (inputType == "1")
                {
                    Console.WriteLine("Формат: гггг.MM.дд чч:мм \"Имя\"");
                    string input = Console.ReadLine();
                    Lesson lesson = ParseLesson(input);
                    listLessons.Add(lesson);
                }
                else if (inputType == "2")
                {
                    Console.WriteLine("Формат: гггг.MM.дд чч:мм \"Имя\" \"Платформа\" Будет запись: true/false");
                    string input = Console.ReadLine();
                    OnlineLesson lesson = ParseOnlineLesson(input);
                    listLessons.Add(lesson);
                }
                else if (inputType == "3")
                {
                    Console.WriteLine("Формат: гггг.MM.дд чч:мм \"Имя\" \"Группа\" Кол-во студентов");
                    string input = Console.ReadLine();
                    GroupLesson lesson = ParseGroupLesson(input);
                    listLessons.Add(lesson);
                }
            }

            Console.WriteLine("\nСписок всех занятий преподавателя Иван:");
            foreach (Lesson lesson in listLessons)
            {
                if (lesson.TeacherName == "Иван")
                {
                    Console.WriteLine(lesson);
                }
            }
        }

        static Lesson ParseLesson(string input)
        {
            string[] parts = input.Split('"');
            string[] dateTimeParts = parts[0].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string teacher = parts[1];

            return new Lesson
            {
                DateLesson = DateTime.Parse(dateTimeParts[0]),
                TimeLesson = TimeSpan.Parse(dateTimeParts[1]),
                TeacherName = teacher
            };
        }

        static OnlineLesson ParseOnlineLesson(string input)
        {
            string[] parts = input.Split('"');
            string[] dateTimeParts = parts[0].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string teacher = parts[1];
            string platform = parts[3];
            bool isRecorded = bool.Parse(parts[4].Trim());

            return new OnlineLesson
            {
                DateLesson = DateTime.Parse(dateTimeParts[0]),
                TimeLesson = TimeSpan.Parse(dateTimeParts[1]),
                TeacherName = teacher,
                Platform = platform,
                IsRecorded = isRecorded
            };
        }

        static GroupLesson ParseGroupLesson(string input)
        {
            string[] parts = input.Split('"');
            string[] dateTimeParts = parts[0].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string teacher = parts[1];
            string groupName = parts[3];
            int count = int.Parse(parts[4].Trim());

            return new GroupLesson
            {
                DateLesson = DateTime.Parse(dateTimeParts[0]),
                TimeLesson = TimeSpan.Parse(dateTimeParts[1]),
                TeacherName = teacher,
                GroupName = groupName,
                StudentsCount = count
            };
        }
    }
}
