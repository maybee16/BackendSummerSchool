using EF.DbModels;
using EF.DbModels.Filters;
using MentorRequests;
using SchoolModels;
using System.Collections.Generic;

namespace ServerService.Mappers.Interfaces
{
    public interface IMentorMapper
    {
        DbMentors ToDbMentor(CreateMentorRequest request);
        MentorModel ToMentor(DbMentors mentors);
        HashSet<MentorModel> ToStudentList(HashSet<DbMentors> dbMentors);
        FindMentorsFilter ToMentorsFilter(FindMentorRequest request);
    }
}
