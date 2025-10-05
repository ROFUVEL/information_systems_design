using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateLessons
{
    public class OnlineLesson : Lesson
    {
        public string Platform { get; set; }
        public bool IsRecorded { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Платформа: {Platform}, Запись: {IsRecorded}";
        }
    }
}
