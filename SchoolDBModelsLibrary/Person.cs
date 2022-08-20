using System;
using WritelineLibrary;


namespace SchoolDBModelsLibrary
{
    public class Person : IPerson
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public Guid DepartmentId { get; set; }

        public bool SetProperties()
        {
            string str;

            ColorMessage.Get("Введите имя:", ConsoleColor.Yellow);

            while (true)
            {
                str = Console.ReadLine();

                if (str == "exit")
                {
                    return false;
                }
                else if (str != "")
                {
                    FirstName = str;
                    break;
                }
                else
                {
                    ColorMessage.Get("Введите корректное значение:", ConsoleColor.Red);
                }
            }

            ColorMessage.Get("Введите фамилию:", ConsoleColor.Yellow);

            while (true)
            {
                str = Console.ReadLine();

                if (str == "exit")
                {
                    return false;
                }
                else if (str != "")
                {
                    LastName = str;
                    break;
                }
                else
                {
                    ColorMessage.Get("Введите корректное значение:", ConsoleColor.Red);
                }
            }

            ColorMessage.Get("Введите отчество:", ConsoleColor.Yellow);
            str = Console.ReadLine();

            if (str == "exit")
            {
                return false;
            }
            else
            {
                Patronymic = str;
            }

            ColorMessage.Get("Введите Id направления:", ConsoleColor.Yellow);

            while (true)
            {
                str = Console.ReadLine();

                if (str == "exit")
                {
                    return false;
                }
                else if (Guid.TryParse(str, out Guid id))
                {
                    DepartmentId = id;
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
            ColorMessage.Get("Введите Id:", ConsoleColor.Yellow);

            while (true)
            {
                string stId = Console.ReadLine();

                if (stId == "exit")
                {
                    return false;
                }
                if (Guid.TryParse(stId, out Guid studentId))
                {
                    Id = studentId;
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
