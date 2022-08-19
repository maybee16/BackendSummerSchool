using EF.DbModels;
using EF.DbModels.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data.Interfaces
{
    public interface IMentorsRepository
    {
        Task<Guid?> AddAsync(DbMentors mentors);
        Task<DbMentors?> GetMentorAsync(Guid id);
        Task<Guid?> UpdateAsync(Guid id, string firstName, string lastName, string patronymic, string departments);
        Task<List<DbMentors>> FindAsync(FindMentorsFilter filter);
        Task DeleteAsync(Guid id);
    }
}
