using ClientService.DepartmentRequests;
using EF.DbModels;
using EF.DbModels.Filters;
using GradeRequests;
using SchoolModels;
using System.Collections.Generic;

namespace ServerService.Mappers
{
    public static class DepartmentMapper
    {
        public static DbDepartments ToDbDepartment(CreateDepartmentRequest request) => new()
        {
            Name = request.Name,
        };

        public static DepartmentModel ToDepartment(DbDepartments departments) => new()
        {
            Id = departments.Id,
            Name = departments.Name,
            Students = StudentMapper.ToStudentList((HashSet<DbStudents>)departments.Students),
            Mentors = MentorMapper.ToStudentList((HashSet<DbMentors>)departments.Mentors)
        };

        public static FindDepartmentsFilter ToDepartmentsFilter(FindDepartmentRequest request)
        {
            FindDepartmentsFilter filter = new();
            filter.NameContains = request.NameContains;

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
