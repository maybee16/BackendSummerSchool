using EF.Data.Interfaces;
using EF.DbModels;
using EF.DbModels.Filters;
using Microsoft.EntityFrameworkCore;

namespace EF.Data
{
    public class MentorsRepository : IMentorsRepository
    {
        private readonly Context _context;

        public MentorsRepository()
        {
            _context = new Context();
        }

        public async Task<Guid?> AddAsync(DbMentors mentors)
        {
            try
            {
                DbDepartments departments = await _context.DbDepartments.FirstAsync(x => x.Name == mentors.Department);
                mentors.DepartmentsId = departments.Id;

                await _context.DbMentors.AddAsync(mentors);
                await _context.SaveChangesAsync();

                return mentors.Id;
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

        public async Task<DbMentors?> GetMentorAsync(Guid id)
        {
            try
            {
                DbMentors mentor = await _context.DbMentors
                    .Include(x => x.Departments)
                    .Include(x => x.StudentsMentors)
                    .FirstAsync(x => x.Id == id);

                return mentor;
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

        public async Task<Guid?> UpdateAsync(Guid id, string firstName, string lastName, string patronymic, string department)
        {
            try
            {
                DbMentors mentors = await _context.DbMentors.FirstAsync(x => x.Id == id);
                DbDepartments departments = await _context.DbDepartments.FirstAsync(x => x.Name == mentors.Department);

                mentors.FirstName = firstName;
                mentors.LastName = lastName;
                mentors.Patronymic = patronymic;
                mentors.Department = department;
                mentors.DepartmentsId = departments.Id;

                _context.DbMentors.Update(mentors);
                await _context.SaveChangesAsync();

                return mentors.Id;
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
                DbMentors mentor = await _context.DbMentors.FirstAsync(x => x.Id == id);

                _context.DbMentors.Remove(mentor);
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

        public async Task<List<DbMentors>> FindAsync(FindMentorsFilter filter)
        {
            try
            {
                if (filter is null)
                {
                    return (List<DbMentors>)Enumerable.Empty<DbMentors>();
                }

                IQueryable<DbMentors> query = _context.DbMentors.AsQueryable();

                if (filter.Department is not null)
                {
                    query = query.Where(x => x.Department == filter.Department);
                }

                if (!string.IsNullOrEmpty(filter.FirstNameContains))
                {
                    query = query.Where(x => x.FirstName.Contains(filter.FirstNameContains));
                }

                if (!string.IsNullOrEmpty(filter.LastNameContains))
                {
                    query = query.Where(x => x.FirstName.Contains(filter.FirstNameContains));
                }

                if (!string.IsNullOrEmpty(filter.PatronymicNameContains))
                {
                    query = query.Where(x => x.FirstName.Contains(filter.FirstNameContains));
                }

                return await query.Skip(filter.SkipCount).Take(filter.TakeCount).ToListAsync();
            }
            catch (ArgumentNullException)
            {
                return (List<DbMentors>)Enumerable.Empty<DbMentors>();
            }
            catch (InvalidOperationException)
            {
                return (List<DbMentors>)Enumerable.Empty<DbMentors>();
            }
        }
    }
}
