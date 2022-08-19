using EF.DbModels;
using EF.DbModels.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data.Interfaces
{
    public interface IStudentsRepository
    {
        Task<Guid?> AddAsync(DbStudents students);
        Task<DbStudents?> GetStudentAsync(Guid id);
        Task<Guid?> UpdateAsync(Guid id, string firstName, string lastName, string patronymic, string department);
        Task<List<DbStudents>> FindAsync(FindStudentsFilter filter);
        Task DeleteAsync(Guid id);
    }
}
