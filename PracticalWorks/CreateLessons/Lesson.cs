using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateLessons
{
    public class Lesson
    {
        public DateTime DateLesson { get; set; }
        public TimeSpan TimeLesson { get; set; }
        public string TeacherName { get; set; }
        public string IdStudent { get; set; }

        public override string ToString()
        {
            return $"Дата:{DateLesson}, Время:{TimeLesson}, Преподаватель:{TeacherName}, Студенческий билет: {IdStudent}";
        }
    }

}
