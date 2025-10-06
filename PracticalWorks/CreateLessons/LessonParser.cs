using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateLessons
{
    public static class LessonParser
    {
        public static List<Lesson> ParseMultiple(string input)
        {
            List<Lesson> lessons = new List<Lesson>();

            string[] objectStrings = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string obj in objectStrings)
            {
                Lesson parsed = ParseSingle(obj.Trim());
                if (parsed != null)
                {
                    lessons.Add(parsed);
                }
            }

            return lessons;
        }

        public static Lesson ParseSingle(string input)
        {
            try
            {
                // Разбиваем по кавычкам
                string[] parts = input.Split('"');
                string[] dateTimeParts = parts[0].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                DateTime date = DateTime.Parse(dateTimeParts[0]);
                TimeSpan time = TimeSpan.Parse(dateTimeParts[1]);
                string teacher = parts[1];
                string idStudent = parts.Length > 3 ? parts[3] : "";

                // --- Базовый урок: 4 части (дата, время, преподаватель, студент)
                if (parts.Length == 5)
                {
                    return new Lesson
                    {
                        DateLesson = date,
                        TimeLesson = time,
                        TeacherName = teacher,
                        IdStudent = idStudent
                    };
                }

                // --- Онлайн занятие: 6 частей (дата, время, преподаватель, студент, платформа, bool)
                if (parts.Length == 7)
                {
                    string platform = parts[5];
                    string afterQuoted = parts[6].Trim();

                    if (bool.TryParse(afterQuoted, out bool isRecorded))
                    {
                        return new OnlineLesson
                        {
                            DateLesson = date,
                            TimeLesson = time,
                            TeacherName = teacher,
                            IdStudent = idStudent,
                            Platform = platform,
                            IsRecorded = isRecorded
                        };
                    }
                }

                // --- Групповое занятие: 6 частей (дата, время, преподаватель, студент, группа, число)
                if (parts.Length == 7)
                {
                    string groupName = parts[5];
                    string afterQuoted = parts[6].Trim();

                    if (int.TryParse(afterQuoted, out int studentsCount))
                    {
                        return new GroupLesson
                        {
                            DateLesson = date,
                            TimeLesson = time,
                            TeacherName = teacher,
                            IdStudent = idStudent,
                            GroupName = groupName,
                            StudentsCount = studentsCount
                        };
                    }
                }

                // Если формат не подходит
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
