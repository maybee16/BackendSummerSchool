using System;
using WritelineLibrary;


namespace SchoolDBModelsLibrary
{
    public class Departments : ITable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool SetDepartment()
        {
            string str;
            ColorMessage.Get("Введите название отделения:", ConsoleColor.Yellow);

            while (true)
            {
                str = Console.ReadLine();
                if (str == "exit")
                {
                    return false;
                }
                else if (str != "")
                {
                    Name = str;
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
            ColorMessage.Get("Введите Id направления:", ConsoleColor.Yellow);

            while (true)
            {
                string str = Console.ReadLine();
                if (str == "exit")
                {
                    return false;
                }
                else if (Guid.TryParse(str, out Guid departmentId))
                {
                    Id = departmentId;
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
