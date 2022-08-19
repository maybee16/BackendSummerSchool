using EF.DbModels;
using EF.DbModels.Filters;
using MentorRequests;
using SchoolModels;
using System.Collections.Generic;

namespace ServerService.Mappers
{
    public static class MentorMapper
    {
        public static DbMentors ToDbMentor(CreateMentorRequest request) => new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Patronymic = request.Patronymic,
            Department = request.Department
        };

        public static MentorModel ToMentor(DbMentors mentors) => new()
        {
            Id = mentors.Id,
            FirstName = mentors.FirstName,
            LastName = mentors.LastName,
            Patronymic = mentors.Patronymic,
            Department = mentors.Department,
            //Grade = students.Grade
        };

        public static HashSet<MentorModel> ToStudentList(HashSet<DbMentors> dbMentors)
        {
            HashSet<MentorModel> mentors = new();

            foreach (var dbMentor in dbMentors)
            {
                mentors.Add(ToMentor(dbMentor));
            }

            return mentors;
        }

        public static FindMentorsFilter ToMentorsFilter(FindMentorRequest request)
        {
            FindMentorsFilter filter = new();
            filter.Department = request.Department;
            filter.FirstNameContains = request.FirstNameContains;
            filter.LastNameContains = request.LastNameContains;
            filter.PatronymicNameContains = request.PatronymicNameContains;

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
