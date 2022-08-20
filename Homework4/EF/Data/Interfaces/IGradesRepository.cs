using EF.DbModels;
using EF.DbModels.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data.Interfaces
{
    public interface IGradesRepository
    {
        Task<Guid?> AddAsync(DbGrades grades);
        Task<DbGrades?> GetGradeAsync(Guid id);
        Task<Guid?> UpdateAsync(Guid id, Guid studentId, int value);
        Task<List<DbGrades>> FindAsync(FindGradesFilter filter);
        Task DeleteAsync(Guid id);
    }
}
