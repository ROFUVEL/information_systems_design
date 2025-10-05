using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateLessons
{
    public class GroupLesson : Lesson
    {
        public string GroupName { get; set; }
        public int StudentsCount { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Группа: {GroupName}, Кол-во студентов: {StudentsCount}";
        }
    }
}
