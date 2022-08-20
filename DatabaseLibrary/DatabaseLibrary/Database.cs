using SchoolDBModelsLibrary;
using System;
using System.Data.SqlClient;
using WritelineLibrary;


namespace DatabaseLibrary
{
    public class Database : IDatabase
    {
        private const string _connString = "Server=localhost\\sqlexpress;Database=SchoolDB;Trusted_Connection=True";

        #region Create
        public void Create(Students student)
        {
            SqlConnection sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string sqlQuery = $"INSERT INTO Students VALUES (NEWID(), '{student.FirstName}', '{student.LastName}', " +
                    $"'{student.Patronymic}', '{student.DepartmentId}')";

            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConnection))
            {
                try
                {
                    ColorMessage.Get($"Создано объектов: {command.ExecuteNonQuery()}", ConsoleColor.Green);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Create(Mentors mentor)
        {
            SqlConnection sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string sqlQuery = $"INSERT INTO Mentors VALUES (NEWID(), '{mentor.FirstName}', '{mentor.LastName}', " +
                    $"'{mentor.Patronymic}', '{mentor.DepartmentId}')";

            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConnection))
            {
                try
                {
                    ColorMessage.Get($"Создано объектов: {command.ExecuteNonQuery()}", ConsoleColor.Green);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Create(Departments department)
        {
            SqlConnection sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string sqlQuery = $"INSERT INTO Departments VALUES (NEWID(), '{department.Name}')";

            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConnection))
            {
                try
                {
                    ColorMessage.Get($"Создано объектов: {command.ExecuteNonQuery()}", ConsoleColor.Green);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Create(Grades grade)
        {
            SqlConnection sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string sqlQuery = $"INSERT INTO Grades VALUES (NEWID(), '{grade.StudentId}', '{grade.Grade}')";

            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConnection))
            {
                try
                {
                    ColorMessage.Get($"Создано объектов: {command.ExecuteNonQuery()}", ConsoleColor.Green);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        #endregion

        #region Read
        public void ReadStudents()
        {
            SqlConnection sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string sqlQuery = $"SELECT * FROM Students";

            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConnection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    ColorMessage.Get("Id\tFirstName\tLastName\tPatronymic\tDepartmentId", ConsoleColor.Blue);

                    try
                    {
                        while (reader.Read())
                        {
                            ColorMessage.Get($"{reader["Id"]}\t{reader["FirstName"]}\t{reader["LastName"]}\t" +
                                $"{reader["Patronymic"]}\t{reader["DepartmentId"]}", ConsoleColor.Green);
                        }
                    }
                    catch (SqlException ex)
                    { 
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        public void ReadMentors()
        {
            SqlConnection sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string sqlQuery = $"SELECT * FROM Mentors";

            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConnection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    ColorMessage.Get("Id\tFirstName\tLastName\tPatronymic\tDepartmentId", ConsoleColor.Blue);

                    try
                    {
                        while (reader.Read())
                        {
                            ColorMessage.Get($"{reader["Id"]}\t{reader["FirstName"]}\t{reader["LastName"]}\t" +
                                $"{reader["Patronymic"]}\t{reader["DepartmentId"]}", ConsoleColor.Green);
                        }
                    }
                    catch (SqlException ex)
                    { 
                        ColorMessage.Get(ex.Message, ConsoleColor.Red);
                    }
                }
            }
        }

        public void ReadDepartments()
        {
            SqlConnection sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string sqlQuery = $"SELECT * FROM Departments";

            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConnection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    ColorMessage.Get("Id\tName", ConsoleColor.Blue);
                    try
                    {
                        while (reader.Read())
                        {
                            ColorMessage.Get($"{reader["Id"]}\t{reader["Name"]}", ConsoleColor.Green);
                        }
                    }
                    catch (SqlException ex)
                    { 
                        ColorMessage.Get(ex.Message, ConsoleColor.Red);
                    }
                }
            }
        }

        public void ReadGrades()
        {
            SqlConnection sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string sqlQuery = $"SELECT * FROM Grades";

            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConnection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    ColorMessage.Get("Id\tStudentId\tGrade", ConsoleColor.Blue);

                    try
                    {
                        while (reader.Read())
                        {
                            ColorMessage.Get($"{reader["Id"]}\t{reader["StudentId"]}\t{reader["Grade"]}", ConsoleColor.Green);
                        }
                    }
                    catch (SqlException ex)
                    { 
                        ColorMessage.Get(ex.Message, ConsoleColor.Red);
                    }
                }
            }
        }
        #endregion

        #region Update
        public void Update(Students student)
        {
            SqlConnection sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string sqlQuery = $"UPDATE Students SET FirstName='{student.FirstName}', LastName='{student.LastName}', " +
                    $"Patronymic='{student.Patronymic}', DepartmentId='{student.DepartmentId}' WHERE Id='{student.Id}'";

            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConnection))
            {
                try
                {
                    ColorMessage.Get($"Обновлено объектов: {command.ExecuteNonQuery()}", ConsoleColor.Green);
                }
                catch (SqlException ex)
                {
                    ColorMessage.Get(ex.Message, ConsoleColor.Red);
                }
            }
        }

        public void Update(Mentors mentor)
        {
            SqlConnection sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string sqlQuery = $"UPDATE Mentors SET FirstName='{mentor.FirstName}', LastName='{mentor.LastName}', " +
                    $"Patronymic='{mentor.Patronymic}', DepartmentId='{mentor.DepartmentId}' WHERE Id='{mentor.Id}'";

            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConnection))
            {
                try
                {
                    ColorMessage.Get($"Обновлено объектов: {command.ExecuteNonQuery()}", ConsoleColor.Green);
                }
                catch (SqlException ex)
                {
                    ColorMessage.Get(ex.Message, ConsoleColor.Red);
                }
            }
        }

        public void Update(Departments department)
        {
            SqlConnection sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string sqlQuery = $"UPDATE Departments SET Name='{department.Name}' WHERE Id='{department.Id}'";

            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConnection))
            {
                try
                {
                    ColorMessage.Get($"Обновлено объектов: {command.ExecuteNonQuery()}", ConsoleColor.Green);
                }
                catch (SqlException ex)
                {
                    ColorMessage.Get(ex.Message, ConsoleColor.Red);
                }
            }
        }

        public void Update(Grades grade)
        {
            SqlConnection sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string sqlQuery = $"UPDATE Grades SET StudentId='{grade.StudentId}', Grade='{grade.Grade}' WHERE Id='{grade.Id}'";

            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConnection))
            {
                try
                {
                    ColorMessage.Get($"Обновлено объектов: {command.ExecuteNonQuery()}", ConsoleColor.Green);
                }
                catch (SqlException ex)
                {
                    ColorMessage.Get(ex.Message, ConsoleColor.Red);
                }
            }
        }
        #endregion

        #region Delete
        public void Delete(Students student)
        {
            SqlConnection sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string sqlQuery = $"DELETE FROM Students WHERE Id='{student.Id}'";

            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConnection))
            {
                try
                {
                    ColorMessage.Get($"Удалено объектов: {command.ExecuteNonQuery()}", ConsoleColor.Green);
                }
                catch (SqlException ex)
                {
                    ColorMessage.Get(ex.Message, ConsoleColor.Red);
                }
            }
        }

        public void Delete(Mentors mentor)
        {
            SqlConnection sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string sqlQuery = $"DELETE FROM Mentors WHERE Id='{mentor.Id}'";

            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConnection))
            {
                try
                {
                    ColorMessage.Get($"Удалено объектов: {command.ExecuteNonQuery()}", ConsoleColor.Green);
                }
                catch (SqlException ex)
                {
                    ColorMessage.Get(ex.Message, ConsoleColor.Red);
                }
            }
        }

        public void Delete(Departments department)
        {
            SqlConnection sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string sqlQuery = $"DELETE FROM Departments WHERE Id='{department.Id}'";

            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConnection))
            {
                try
                {
                    ColorMessage.Get($"Удалено объектов: {command.ExecuteNonQuery()}", ConsoleColor.Green);
                }
                catch (SqlException ex)
                {
                    ColorMessage.Get(ex.Message, ConsoleColor.Red);
                }
            }
        }

        public void Delete(Grades grade)
        {
            SqlConnection sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string sqlQuery = $"DELETE FROM Grades WHERE Id='{grade.Id}'";

            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConnection))
            {
                try
                {
                    ColorMessage.Get($"Удалено объектов: {command.ExecuteNonQuery()}", ConsoleColor.Green);
                }
                catch (SqlException ex)
                {
                    ColorMessage.Get(ex.Message, ConsoleColor.Red);
                }
            }
        }
        #endregion
    }
}
