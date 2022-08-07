using DatabaseLibrary;
using SchoolDBModelsLibrary;
using System;
using System.Collections.Generic;
using WritelineLibrary;

namespace ConsoleLibrary
{
    public class Menu
    {
        List<string> tableList = new() { "Students", "Mentors", "Departments", "Grades" };

        #region Students operations
        private void CreateStudents()
        {
            Students student = new();

            if (!student.SetProperties())
            {
                return;
            }

            Database database = new();
            database.Create(student);
        }

        private void ReadStudents()
        {
            Database database = new();
            database.ReadStudents();
        }

        private void UpdateStudents()
        {
            Students student = new();

            if (!student.SetId())
            {
                return;
            }

            if (!student.SetProperties())
            {
                return;
            }

            Database database = new();
            database.Update(student);
        }

        private void DeleteStudents()
        {
            Students student = new();

            if (!student.SetId())
            {
                return;
            }

            Database database = new();
            database.Delete(student);
        }
        #endregion

        #region Mentors operations
        private void CreateMentors()
        {
            Mentors mentor = new();

            if (!mentor.SetProperties())
            {
                return;
            }

            Database database = new();
            database.Create(mentor);
        }

        private void ReadMentors()
        {
            Database database = new();
            database.ReadMentors();
        }

        private void UpdateMentors()
        {
            Mentors mentor = new();

            if (!mentor.SetId())
            {
                return;
            }

            if (!mentor.SetProperties())
            {
                return;
            }

            Database database = new();
            database.Update(mentor);
        }

        private void DeleteMentors()
        {
            Mentors mentor = new();

            if (!mentor.SetId())
            {
                return;
            }

            Database database = new();
            database.Delete(mentor);
        }
        #endregion

        #region Departments operations
        private void CreateDepartments()
        {
            Departments department = new();

            if (!department.SetDepartment())
            {
                return;
            }

            Database database = new();
            database.Create(department);
        }

        private void ReadDepartments()
        {
            Database database = new();
            database.ReadDepartments();
        }

        private void UpdateDepartments()
        {
            Departments department = new();

            if (!department.SetId())
            {
                return;
            }

            if (!department.SetDepartment())
            {
                return;
            }

            Database database = new();
            database.Update(department);
        }

        private void DeleteDepartments()
        {
            Departments department = new();

            if (!department.SetId())
            {
                return;
            }

            Database database = new();
            database.Delete(department);
        }
        #endregion

        #region Grades operations
        private void CreateGrades()
        {
            Grades grade = new();

            if (!grade.SetGrade())
            {
                return;
            }

            Database database = new();
            database.Create(grade);
        }

        private void ReadGrades()
        {
            Database database = new();
            database.ReadGrades();
        }

        private void UpdateGrades()
        {
            Grades grade = new();

            if (!grade.SetId())
            {
                return;
            }

            if (!grade.SetGrade())
            {
                return;
            }

            Database database = new();
            database.Update(grade);
        }

        private void DeleteGrades()
        {
            Grades grade = new();

            if (!grade.SetId())
            {
                return;
            }

            Database database = new();
            database.Delete(grade);
        }
        #endregion

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
                        CreateStudents();
                    }
                    else if (tableName == tableList[1])
                    {
                        CreateMentors();
                    }
                    else if (tableName == tableList[2])
                    {
                        CreateDepartments();
                    }
                    else if (tableName == tableList[3])
                    {
                        CreateGrades();
                    }
                }
                else if (choice == "2")
                {
                    if (tableName == tableList[0])
                    {
                        ReadStudents();
                    }
                    else if (tableName == tableList[1])
                    {
                        ReadMentors();
                    }
                    else if (tableName == tableList[2])
                    {
                        ReadDepartments();
                    }
                    else if (tableName == tableList[3])
                    {
                        ReadGrades();
                    }
                }
                else if (choice == "3")
                {
                    if (tableName == tableList[0])
                    {
                        UpdateStudents();
                    }
                    else if (tableName == tableList[1])
                    {
                        UpdateMentors();
                    }
                    else if (tableName == tableList[2])
                    {
                        UpdateDepartments();
                    }
                    else if (tableName == tableList[3])
                    {
                        UpdateGrades();
                    }
                }
                else if (choice == "4")
                {
                    if (tableName == tableList[0])
                    {
                        DeleteStudents();
                    }
                    else if (tableName == tableList[1])
                    {
                        DeleteMentors();
                    }
                    else if (tableName == tableList[2])
                    {
                        DeleteDepartments();
                    }
                    else if (tableName == tableList[3])
                    {
                        DeleteGrades();
                    }
                }
                else if (choice == "5")
                {
                    break;
                }
            }
        }

        private void GetOperList()
        {
            ColorMessage.Get("Выберите операцию:\n" +
                      "1. Добавить данные\n" +
                      "2. Получить данные\n" +
                      "3. Обновить данные\n" +
                      "4. Удалить данные\n" +
                      "5. Вернуться\n", ConsoleColor.Yellow);
        }

        public void Run()
        {
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
