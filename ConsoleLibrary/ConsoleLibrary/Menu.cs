using EF;
using EF.Data;
using EF.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using WritelineLibrary;

namespace ConsoleLibrary
{
    public class Menu
    {
        List<string> tableList = new() { "Students", "Mentors", "Departments", "Grades" };

        StudentRepository studentRepository = new();
        MentorsRepository mentorsRepository = new();
        DepartmentsRepository departmentsRepository = new();
        GradesRepository gradesRepository = new();

        private static void SetStudents(Students students)
        {
            string str;

            ColorMessage.Get("Введите имя:", ConsoleColor.Yellow);

            while (true)
            {
                str = Console.ReadLine();

                if (str == "exit")
                {
                    return;
                }
                else if (str != "")
                {
                    students.FirstName = str;
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
                    return;
                }
                else if (str != "")
                {
                    students.LastName = str;
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
                return;
            }
            else
            {
                students.Patronymic = str;
            }

            ColorMessage.Get("Введите Id направления:", ConsoleColor.Yellow);

            while (true)
            {
                str = Console.ReadLine();

                if (str == "exit")
                {
                    return;
                }
                else if (Guid.TryParse(str, out Guid id))
                {
                    students.DepartmentsId = id;
                    break;
                }
                else
                {
                    ColorMessage.Get("Введите корректное значение:", ConsoleColor.Red);
                }
            }
        }

        private static void SetMentors(Mentors mentors)
        {
            string str;

            ColorMessage.Get("Введите имя:", ConsoleColor.Yellow);

            while (true)
            {
                str = Console.ReadLine();

                if (str == "exit")
                {
                    return;
                }
                else if (str != "")
                {
                    mentors.FirstName = str;
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
                    return;
                }
                else if (str != "")
                {
                    mentors.LastName = str;
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
                return;
            }
            else
            {
                mentors.Patronymic = str;
            }

            ColorMessage.Get("Введите Id направления:", ConsoleColor.Yellow);

            while (true)
            {
                str = Console.ReadLine();

                if (str == "exit")
                {
                    return;
                }
                else if (Guid.TryParse(str, out Guid id))
                {
                    mentors.DepartmentsId = id;
                    break;
                }
                else
                {
                    ColorMessage.Get("Введите корректное значение:", ConsoleColor.Red);
                }
            }
        }

        private static void SetDepartments(Departments departments)
        {
            string str;
            ColorMessage.Get("Введите название отделения:", ConsoleColor.Yellow);

            while (true)
            {
                str = Console.ReadLine();
                if (str == "exit")
                {
                    return;
                }
                else if (str != "")
                {
                    departments.Name = str;
                    break;
                }
                else
                {
                    ColorMessage.Get("Введите корректное значение:", ConsoleColor.Red);
                }
            }
        }

        private static void SetGrades(Grades grades)
        {
            string str;
            ColorMessage.Get("Введите id студента:", ConsoleColor.Yellow);

            while (true)
            {
                str = Console.ReadLine();
                if (str == "exit")
                {
                    return;
                }
                else if (Guid.TryParse(str, out Guid studentId))
                {
                    grades.StudentId = studentId;
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
                    return;
                }
                else if (int.TryParse(str, out int val))
                {
                    grades.Value = val;
                    break;
                }
                else
                {
                    ColorMessage.Get("Введите корректное значение:", ConsoleColor.Red);
                }
            }
        }

        private static Guid GetId()
        {
            ColorMessage.Get("Введите Id:", ConsoleColor.Yellow);

            while (true)
            {
                string str = Console.ReadLine();
                //if (str == "exit")
                //{
                //    return ;
                //}
                if (Guid.TryParse(str, out Guid id))
                {
                    return id;
                }
                else
                {
                    ColorMessage.Get("Введите корректное значение:", ConsoleColor.Red);
                }
            }
        }

        private void Operations(string tableName)
        {
            while (true)
            {
                GetOperList();
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    if (tableName == tableList[0])
                    {
                        Students students = new()
                        {
                            Id = Guid.NewGuid()
                        };

                        SetStudents(students);
                        studentRepository.Add(students);
                    }
                    else if (tableName == tableList[1])
                    {
                        Mentors mentors = new()
                        {
                            Id = Guid.NewGuid()
                        };

                        SetMentors(mentors);
                        mentorsRepository.Add(mentors);
                    }
                    else if (tableName == tableList[2])
                    {
                        Departments departments = new()
                        {
                            Id = Guid.NewGuid()
                        };

                        SetDepartments(departments);
                        departmentsRepository.Add(departments);
                    }
                    else if (tableName == tableList[3])
                    {
                        Grades grades = new()
                        {
                            Id = Guid.NewGuid()
                        };

                        SetGrades(grades);
                        gradesRepository.Add(grades);
                    }
                }
                else if (choice == "2")
                {
                    if (tableName == tableList[0])
                    {
                        studentRepository.GetStudent(GetId());
                    }
                    else if (tableName == tableList[1])
                    {
                        mentorsRepository.GetMentor(GetId());
                    }
                    else if (tableName == tableList[2])
                    {
                        departmentsRepository.GetDepartment(GetId());
                    }
                    else if (tableName == tableList[3])
                    {
                        gradesRepository.GetGrade(GetId());
                    }
                }
                else if (choice == "3")
                {
                    if (tableName == tableList[0])
                    {
                        studentRepository.Get();
                    }
                    else if (tableName == tableList[1])
                    {
                        mentorsRepository.Get();
                    }
                    else if (tableName == tableList[2])
                    {
                        departmentsRepository.Get();
                    }
                    else if (tableName == tableList[3])
                    {
                        gradesRepository.Get();
                    }
                }
                else if (choice == "4")
                {
                    Guid id;
                    if (tableName == tableList[0])
                    {
                        id = GetId();
                        Students students = new();
                        SetStudents(students);

                        studentRepository.Update(
                            id,
                            students.FirstName,
                            students.LastName,
                            students.Patronymic,
                            students.DepartmentsId);
                    }
                    else if (tableName == tableList[1])
                    {
                        id = GetId();
                        Mentors mentors = new();
                        SetMentors(mentors);

                        mentorsRepository.Update(
                            id,
                            mentors.FirstName,
                            mentors.LastName,
                            mentors.Patronymic,
                            mentors.DepartmentsId);
                    }
                    else if (tableName == tableList[2])
                    {
                        id = GetId();
                        Departments departments = new();
                        SetDepartments(departments);

                        departmentsRepository.Update(
                            id,
                            departments.Name);
                    }
                    else if (tableName == tableList[3])
                    {
                        id = GetId();
                        Grades grades = new();
                        SetGrades(grades);

                        gradesRepository.Update(
                            id,
                            grades.StudentId,
                            grades.Value);
                    }
                }
                else if (choice == "5")
                {
                    if (tableName == tableList[0])
                    {
                        studentRepository.Delete(GetId());
                    }
                    else if (tableName == tableList[1])
                    {
                        mentorsRepository.Delete(GetId());
                    }
                    else if (tableName == tableList[2])
                    {
                        departmentsRepository.Delete(GetId());
                    }
                    else if (tableName == tableList[3])
                    {
                        gradesRepository.Delete(GetId());
                    }
                }
                else if (choice == "6")
                {
                    break;
                }
            }
        }

        private static void GetOperList()
        {
            ColorMessage.Get("Выберите операцию:\n" +
                      "1. Добавить данные\n" +
                      "2. Получить данные по Id\n" +
                      "3. Получить всю таблицу\n" +
                      "4. Обновить данные\n" +
                      "5. Удалить данные\n" +
                      "6. Вернуться\n" +
                      "'exit' - отменить операцию\n", ConsoleColor.Yellow);
        }

        public void Run()
        {
            using Context context = new();
            //context.Database.EnsureCreated();
            context.Database.Migrate();

            while (true)
            {
                ColorMessage.Get("Выберите таблицу:\n" +
                "1. Students\n" +
                "2. Mentors\n" +
                "3. Departments\n" +
                "4. Grades\n" +
                "5. Завершить работу\n", ConsoleColor.Yellow);

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Operations(tableList[0]);
                }
                else if (choice == "2")
                {
                    Operations(tableList[1]);
                }
                else if (choice == "3")
                {
                    Operations(tableList[2]);
                }
                else if (choice == "4")
                {
                    Operations(tableList[3]);
                }
                else if (choice == "5")
                {
                    break;
                }
            }
        }
    }
}
