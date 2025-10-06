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

                if (parts.Length == 5)
                {
                    string secondString = parts[3];
                    string afterQuoted = parts[4].Trim();

                    if (bool.TryParse(afterQuoted, out bool isRecorded))
                    {
                        return new OnlineLesson
                        {
                            DateLesson = date,
                            TimeLesson = time,
                            TeacherName = teacher,
                            Platform = secondString,
                            IsRecorded = isRecorded
                        };
                    }

                    if (int.TryParse(afterQuoted, out int studentsCount))
                    {
                        return new GroupLesson
                        {
                            DateLesson = date,
                            TimeLesson = time,
                            TeacherName = teacher,
                            GroupName = secondString,
                            StudentsCount = studentsCount
                        };
                    }

                    if (!string.IsNullOrEmpty(secondString) && !string.IsNullOrEmpty(afterQuoted))
                    {
                        return new LessonInPairs
                        {
                            DateLesson = date,
                            TimeLesson = time,
                            TeacherName = teacher,
                            FriendName = secondString,
                            FriendAge = afterQuoted
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
