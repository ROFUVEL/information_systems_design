using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateLessons
{
    public static class FileHandler
    {
        public static string ReadFile(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"Файл {path} не найден.");
                return string.Empty;
            }

            Console.WriteLine($"Данные считаны из файла {path}.");
            return File.ReadAllText(path);
        }

        public static void WriteFile(string path, IEnumerable<Lesson> lessons)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (Lesson lesson in lessons)
                {
                    writer.WriteLine(lesson);
                }
            }
        }
    }
}
