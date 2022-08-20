using EF.DbModels;
using EF.DbModels.Filters;
using GradeRequests;
using SchoolModels;

namespace ServerService.Mappers.Interfaces
{
    public interface IGradeMapper
    {
        DbGrades ToDbGrade(CreateGradeRequest request);
        GradeModel ToGrade(DbGrades grades);
        FindGradesFilter ToGradesFilter(FindGradeRequest request);
    }
}
