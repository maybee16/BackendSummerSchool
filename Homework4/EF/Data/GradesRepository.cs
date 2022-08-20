using EF.Data.Interfaces;
using EF.DbModels;
using EF.DbModels.Filters;
using Microsoft.EntityFrameworkCore;

namespace EF.Data
{
    public class GradesRepository : IGradesRepository
    {
        private readonly Context _context;

        public GradesRepository()
        {
            _context = new Context();
        }

        public async Task<Guid?> AddAsync(DbGrades grades)
        {
            try
            {
                await _context.DbGrades.AddAsync(grades);
                await _context.SaveChangesAsync();

                return grades.Id;
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

        public async Task<DbGrades?> GetGradeAsync(Guid id)
        {
            try
            {
                DbGrades grade = await _context.DbGrades.Include(x => x.Student).FirstAsync(x => x.Id == id);

                return grade;
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

        public async Task<Guid?> UpdateAsync(Guid id, Guid studentId, int value)
        {
            try
            {
                DbGrades grade = await _context.DbGrades.FirstAsync(x => x.Id == id);

                grade.StudentId = studentId;
                grade.Value = value;

                _context.DbGrades.Update(grade);
                await _context.SaveChangesAsync();

                return grade.Id;
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
                DbGrades grade = await _context.DbGrades.FirstAsync(x => x.Id == id);

                _context.DbGrades.Remove(grade);
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

        public async Task<List<DbGrades>> FindAsync(FindGradesFilter filter)
        {
            try
            {
                if (filter is null)
                {
                    return (List<DbGrades>)Enumerable.Empty<DbGrades>();
                }

                IQueryable<DbGrades> query = _context.DbGrades.AsQueryable();

                if (filter.Value is not null)
                {
                    query = query.Where(x => x.Value == filter.Value);
                }

                return await query.Skip(filter.SkipCount).Take(filter.TakeCount).ToListAsync();
            }
            catch (ArgumentNullException)
            {
                return (List<DbGrades>)Enumerable.Empty<DbGrades>();
            }
            catch (InvalidOperationException)
            {
                return (List<DbGrades>)Enumerable.Empty<DbGrades>();
            }
        }
    }
}
