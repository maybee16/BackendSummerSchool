using EF.DbModels;
using EF.DbModels.Filters;
using GradeRequests;
using SchoolModels;
using ServerService.Mappers.Interfaces;

namespace ServerService.Mappers
{
    public class GradeMapper : IGradeMapper
    {
        public DbGrades ToDbGrade(CreateGradeRequest request)
        {
            return request is null ? default : new DbGrades
            {
                StudentId = request.StudentId,
                Value = request.Value
            };
        }

        public GradeModel ToGrade(DbGrades grades) 
        {
            return grades is null ? default : new GradeModel
            {
                Id = grades.Id,
                StudentId = grades.Id,
                Value = grades.Value
            };
        }

        public FindGradesFilter ToGradesFilter(FindGradeRequest request)
        {
            if (request is not null)
            {
                FindGradesFilter filter = new();
                filter.Value = request.Value;

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
