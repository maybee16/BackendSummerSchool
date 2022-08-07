using System;
using WritelineLibrary;


namespace SchoolDBModelsLibrary
{
    public class Grades : ITable
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public int Grade { get; set; }

        public bool SetGrade()
        {
            string str;
            ColorMessage.Get("Введите id студента:", ConsoleColor.Yellow);

            while (true)
            {
                str = Console.ReadLine();
                if (str == "exit")
                {
                    return false;
                }
                else if (Guid.TryParse(str, out Guid studentId))
                {
                    StudentId = studentId;
                    break;
                }
                else
                {
                    ColorMessage.Get("Введите корректное значение:", ConsoleColor.Red);
                }
            }

            ColorMessage.Get("Введите оценку:", ConsoleColor.Yellow);

            while (true)
            {
                str = Console.ReadLine();
                if (str == "exit")
                {
                    return false;
                }
                else if (int.TryParse(str, out int grade))
                {
                    Grade = grade;
                    return true;
                }
                else
                {
                    ColorMessage.Get("Введите корректное значение:", ConsoleColor.Red);
                }
            }
        }

        public bool SetId()
        {
            ColorMessage.Get("Введите Id оценки:", ConsoleColor.Yellow);

            while (true)
            {
                string str = Console.ReadLine();
                if (str == "exit")
                {
                    return false;
                }
                else if (Guid.TryParse(str, out Guid gradeId))
                {
                    Id = gradeId;
                    return true;
                }
                else
                {
                    ColorMessage.Get("Введите корректное значение:", ConsoleColor.Red);
                }
            }
        }
    }
}
