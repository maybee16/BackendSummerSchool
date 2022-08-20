using EF.Data.Interfaces;
using EF.DbModels;
using EF.DbModels.Filters;
using Microsoft.EntityFrameworkCore;

namespace EF.Data
{
    public class DepartmentsRepository : IDepartmentsRepository
    {
        private readonly Context _context;

        public DepartmentsRepository()
        {
            _context = new Context();
        }

        public async Task<Guid?> AddAsync(DbDepartments departments)
        {
            try
            {
                await _context.DbDepartments.AddAsync(departments);
                await _context.SaveChangesAsync();

                return departments.Id;
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public async Task<DbDepartments?> GetDepartmentAsync(Guid id)
        {
            try
            {
                DbDepartments department = await _context.DbDepartments
                    .Include(x => x.Students)
                    .Include(x => x.Mentors)
                    .FirstAsync(x => x.Id == id);

                return department;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public async Task<Guid?> UpdateAsync(Guid id, string name)
        {
            try
            {
                DbDepartments department = await _context.DbDepartments.FirstAsync(x => x.Id == id);

                department.Name = name;

                _context.DbDepartments.Update(department);
                await _context.SaveChangesAsync();

                return department.Id;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                DbDepartments department = await _context.DbDepartments.FirstAsync(x => x.Id == id);

                _context.DbDepartments.Remove(department);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentNullException)
            {
            }
            catch (InvalidOperationException)
            {
            }
            catch (DbUpdateConcurrencyException)
            {
            }
            catch (DbUpdateException)
            {
            }
        }

        public async Task<List<DbDepartments>> FindAsync(FindDepartmentsFilter filter)
        {
            try
            {
                if (filter is null)
                {
                    return (List<DbDepartments>)Enumerable.Empty<DbDepartments>();
                }

                IQueryable<DbDepartments> query = _context.DbDepartments.AsQueryable();

                if (!string.IsNullOrEmpty(filter.NameContains))
                {
                    query = query.Where(x => x.Name.Contains(filter.NameContains));
                }

                return await query.Skip(filter.SkipCount).Take(filter.TakeCount).ToListAsync();
            }
            catch (ArgumentNullException)
            {
                return (List<DbDepartments>)Enumerable.Empty<DbDepartments>();
            }
            catch (InvalidOperationException)
            {
                return (List<DbDepartments>)Enumerable.Empty<DbDepartments>();
            }
        }
    }
}
