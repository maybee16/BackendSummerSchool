using ClientService.DepartmentRequests;
using EF.DbModels;
using EF.DbModels.Filters;
using GradeRequests;
using SchoolModels;
using ServerService.Mappers.Interfaces;
using System.Collections.Generic;

namespace ServerService.Mappers
{
    public class DepartmentMapper : IDepartmentMapper
    {
        private readonly IStudentMapper _studentMapper;
        private readonly IMentorMapper _mentorMapper;

        public DepartmentMapper(
            IStudentMapper studentMapper,
            IMentorMapper mentorMapper)
        {
            _studentMapper = studentMapper;
            _mentorMapper = mentorMapper;
        }

        public DbDepartments ToDbDepartment(CreateDepartmentRequest request)
        {
            return request is null ? default : new DbDepartments
            {
                Name = request.Name,
            };
        }

        public DepartmentModel ToDepartment(DbDepartments departments)
        {
            return departments is null ? default : new DepartmentModel
            {
                Id = departments.Id,
                Name = departments.Name,
                Students = _studentMapper.ToStudentList((HashSet<DbStudents>)departments.Students),
                Mentors = _mentorMapper.ToStudentList((HashSet<DbMentors>)departments.Mentors)
            };
        }

        public FindDepartmentsFilter ToDepartmentsFilter(FindDepartmentRequest request)
        {
            if (request is not null)
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
            else
            {
                return default;
            }
        }
    }
}
