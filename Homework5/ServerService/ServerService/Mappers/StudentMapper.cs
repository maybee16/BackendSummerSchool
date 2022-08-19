using EF.DbModels;
using EF.DbModels.Filters;
using SchoolModels;
using StudentRequests;
using System.Collections.Generic;

namespace ServerService.Mappers
{
    public static class StudentMapper
    {
        public static DbStudents ToDbStudent(CreateStudentRequest request) => new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Patronymic = request.Patronymic,
            Department = request.Department
        };

        public static StudentModel ToStudent(DbStudents students) => new()
        {
            Id = students.Id,
            FirstName = students.FirstName,
            LastName = students.LastName,
            Patronymic = students.Patronymic,
            Department = students.Department,
            Grade = GradeMapper.ToGrade(students.Grade)
        };

        public static HashSet<StudentModel> ToStudentList(HashSet<DbStudents> dbStudents)
        {
            HashSet<StudentModel> students = new();
            foreach (var dbStudent in dbStudents)
            {
                students.Add(ToStudent(dbStudent));
            }

            return students;
        }

        public static FindStudentsFilter ToStudentsFilter(FindStudentRequest request)
        {
            FindStudentsFilter filter = new();
            filter.Department = request.Department;
            filter.FirstNameContains = request.FirstNameContains;
            filter.LastNameContains = request.LastNameContains;
            filter.PatronymicNameContains = request.PatronymicNameContains;

            if (request.GradeValue.HasValue)
            {
                filter.GradeValue = (int)request.GradeValue;
            }

            if (request.TakeCount.HasValue)
            {
                filter.TakeCount = (int)request.TakeCount;
            }

            if (request.SkipCount.HasValue)
            {
                filter.SkipCount = (int)request.SkipCount;
            }

            return filter;
        }

    }
}
