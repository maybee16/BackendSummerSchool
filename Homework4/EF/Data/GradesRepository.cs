using EF.Data.Interfaces;
using EF.DbModels;
using EF.DbModels.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritelineLibrary;

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
            catch (DbUpdateConcurrencyException ex)
            {
                return null;
            }
            catch (DbUpdateException ex)
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
            catch (ArgumentNullException ex)
            {
                return null;
            }
            catch (InvalidOperationException ex)
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
                DbGrades grade = await _context.DbGrades.FirstAsync(x => x.Id == id);

                _context.DbGrades.Remove(grade);
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
            catch (ArgumentNullException ex)
            {
                return (List<DbGrades>)Enumerable.Empty<DbGrades>();
            }
            catch (InvalidOperationException ex)
            {
                return (List<DbGrades>)Enumerable.Empty<DbGrades>();
            }
        }
    }
}
