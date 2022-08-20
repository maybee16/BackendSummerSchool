using EF.DbModels;
using EF.DbModels.Filters;
using MentorRequests;
using SchoolModels;
using ServerService.Mappers.Interfaces;
using System.Collections.Generic;

namespace ServerService.Mappers
{
    public class MentorMapper : IMentorMapper
    {
        public DbMentors ToDbMentor(CreateMentorRequest request)
        {
            return request is null ? default : new DbMentors
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Patronymic = request.Patronymic,
                Department = request.Department
            };
        }

        public MentorModel ToMentor(DbMentors mentors)
        {
            return mentors is null ? default : new MentorModel
            {
                Id = mentors.Id,
                FirstName = mentors.FirstName,
                LastName = mentors.LastName,
                Patronymic = mentors.Patronymic,
                Department = mentors.Department,
            };
        }

        public HashSet<MentorModel> ToMentorList(HashSet<DbMentors> dbMentors)
        {
            if (dbMentors is not null)
            {
                HashSet<MentorModel> mentors = new();

                foreach (var dbMentor in dbMentors)
                {
                    mentors.Add(ToMentor(dbMentor));
                }

                return mentors;
            }
            else
            {
                return default;
            }
        }

        public FindMentorsFilter ToMentorsFilter(FindMentorRequest request)
        {
            if (request is not null)
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
            else
            {
                return default;
            }
        }
    }
}
