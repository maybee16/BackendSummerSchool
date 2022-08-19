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
            catch (DbUpdateConcurrencyException ex)
            {
                return null;
            }
            catch (DbUpdateException ex)
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
            catch (ArgumentNullException ex)
            {
                return null;
            }
            catch (InvalidOperationException ex)
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
            catch (ArgumentNullException ex)
            {
                return null;
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return null;
            }
            catch (DbUpdateException ex)
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
            catch (ArgumentNullException ex)
            {
            }
            catch (InvalidOperationException ex)
            {
            }
            catch (DbUpdateConcurrencyException ex)
            {
            }
            catch (DbUpdateException ex)
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
            catch (ArgumentNullException ex)
            {
                return (List<DbDepartments>)Enumerable.Empty<DbDepartments>();
            }
            catch (InvalidOperationException ex)
            {
                return (List<DbDepartments>)Enumerable.Empty<DbDepartments>();
            }
        }
    }
}
