using EF.DbModels;
using EF.DbModels.Filters;
using GradeRequests;
using SchoolModels;

namespace ServerService.Mappers
{
    public static class GradeMapper
    {
        public static DbGrades ToDbGrade(CreateGradeRequest request) => new()
        {
            StudentId = request.StudentId,
            Value = request.Value
        };

        public static GradeModel ToGrade(DbGrades grades) => new()
        {
            Id = grades.Id,
            StudentId = grades.Id,
            Value = grades.Value
        };

        public static FindGradesFilter ToGradesFilter(FindGradeRequest request)
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

    }
}
