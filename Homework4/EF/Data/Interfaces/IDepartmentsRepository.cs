using EF.DbModels;
using EF.DbModels.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data.Interfaces
{
    public interface IDepartmentsRepository
    {
        Task<Guid?> AddAsync(DbDepartments departments);
        Task<DbDepartments?> GetDepartmentAsync(Guid id);
        Task<Guid?> UpdateAsync(Guid id, string name);
        Task<List<DbDepartments>> FindAsync(FindDepartmentsFilter filter);
        Task DeleteAsync(Guid id);
    }
}
