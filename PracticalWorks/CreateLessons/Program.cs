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
                Console.WriteLine("Хотите добавить занятие? (y/n)");

                string inputYesOrNo = Console.ReadLine();

                if (inputYesOrNo == "n")
                    break;
                else if (inputYesOrNo == "y")
                {
                    Console.WriteLine("Введите данные в форме гггг.MM.дд чч:мм \"Имя\"");

                    string inputData = Console.ReadLine();
                    string[] arrayStringsFromInput = inputData.Split('"');
                    string[] arrayData = arrayStringsFromInput[0].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string teacherName = arrayStringsFromInput[1];

                    Lesson lesson = new Lesson
                    {
                        DateLesson = DateTime.Parse(arrayData[0]),
                        TimeLesson = TimeSpan.Parse(arrayData[1]),
                        TeacherName = teacherName,
                    };
                    listLessons.Add(lesson);
                }
            }

            foreach (Lesson lesson in listLessons)
            {
                if (lesson.TeacherName == "Иван")
                {
                    Console.WriteLine(lesson);
                }
            }
        }

    }
}
