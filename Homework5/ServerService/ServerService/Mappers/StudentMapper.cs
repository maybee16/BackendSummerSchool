using EF.DbModels;
using EF.DbModels.Filters;
using SchoolModels;
using ServerService.Mappers.Interfaces;
using StudentRequests;
using System.Collections.Generic;

namespace ServerService.Mappers
{
    public class StudentMapper : IStudentMapper
    {
        private readonly IGradeMapper _gradeMapper;

        public StudentMapper(IGradeMapper gradeMapper)
        {
            _gradeMapper = gradeMapper;
        }

        public DbStudents ToDbStudent(CreateStudentRequest request)
        {
            return request is null ? default : new DbStudents
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Patronymic = request.Patronymic,
                Department = request.Department
            };
        }

        public StudentModel ToStudent(DbStudents students)
        {
            return students is null ? default : new StudentModel
            {
                Id = students.Id,
                FirstName = students.FirstName,
                LastName = students.LastName,
                Patronymic = students.Patronymic,
                Department = students.Department,
                Grade = _gradeMapper.ToGrade(students.Grade)
            };
        }

        public HashSet<StudentModel> ToStudentList(HashSet<DbStudents> dbStudents)
        {
            if (dbStudents is not null)
            {
                HashSet<StudentModel> students = new();
                foreach (var dbStudent in dbStudents)
                {
                    students.Add(ToStudent(dbStudent));
                }

                return students;
            }
            else
            {
                return default;
            }
        }

        public FindStudentsFilter ToStudentsFilter(FindStudentRequest request)
        {
            if (request is not null)
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
            else
            {
                return default;
            }
        }
    }
}
