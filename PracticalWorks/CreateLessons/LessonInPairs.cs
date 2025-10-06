using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateLessons
{
    public  class LessonInPairs : Lesson
    {
        public string FriendName { get; set; }
        public string FriendAge  { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Имя друга: {FriendName}, Возраст друга: {FriendAge}";
        }
    }
}
