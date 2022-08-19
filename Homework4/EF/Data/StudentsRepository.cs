using EF.Data.Interfaces;
using EF.DbModels;
using EF.DbModels.Filters;
using Microsoft.EntityFrameworkCore;
using WritelineLibrary;

namespace EF.Data
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly Context _context;
        //private readonly IContext _context;

        //public StudentRepository(IContext context)
        //{
        //    _context = context;
        //}

        public StudentsRepository()
        {
            _context = new Context();
        }

        public async Task<Guid?> AddAsync(DbStudents students)
        {
            try
            {
                DbDepartments departments = await _context.DbDepartments.FirstAsync(x => x.Name == students.Department);
                students.DepartmentsId = departments.Id;

                await _context.DbStudents.AddAsync(students);
                await _context.SaveChangesAsync();

                return students.Id;
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

        public async Task<DbStudents?> GetStudentAsync(Guid id)
        {
            try
            {
                DbStudents student = await _context.DbStudents
                    .Include(x => x.Departments)
                    .Include(x => x.Grade)
                    .Include(x => x.StudentsMentors)
                    .FirstAsync(x => x.Id == id);

                return student;
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

        public async Task<Guid?> UpdateAsync(Guid id, string firstName, string lastName, string patronymic, string department)
        {
            try
            {
                DbStudents students = await _context.DbStudents.FirstAsync(x => x.Id == id);

                DbDepartments departments = await _context.DbDepartments.FirstAsync(x => x.Name == students.Department);

                students.FirstName = firstName;
                students.LastName = lastName;
                students.Patronymic = patronymic;
                students.DepartmentsId = departments.Id;
                students.Departments = departments;

                _context.DbStudents.Update(students);
                await _context.SaveChangesAsync();

                return students.Id;
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
                DbStudents student = await _context.DbStudents.FirstAsync(x => x.Id == id);

                _context.DbStudents.Remove(student);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentNullException ex)
            {
                //ColorMessage.Get(ex.Message, ConsoleColor.Red);
            }
            catch (InvalidOperationException ex)
            {
                //ColorMessage.Get(ex.Message, ConsoleColor.Red);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //ColorMessage.Get(ex.Message, ConsoleColor.Red);
            }
            catch (DbUpdateException ex)
            {
                //ColorMessage.Get(ex.Message, ConsoleColor.Red);
            }

            //ColorMessage.Get("Объект удалён", ConsoleColor.Green);
        }

        public async Task<List<DbStudents>> FindAsync(FindStudentsFilter filter)
        {
            try
            {
                if (filter is null)
                {
                    return (List<DbStudents>)Enumerable.Empty<DbStudents>();
                }

                IQueryable<DbStudents> query = _context.DbStudents.Include(x => x.Grade).AsQueryable();

                if (filter.Department is not null)
                {
                    //DbDepartments dep = await _context.DbDepartments.FirstAsync(x => x.Name == filter.Department);

                    query = query.Where(x => x.Department == filter.Department);
                }

                if (filter.GradeValue is not null)
                {
                    query = query.Where(x => x.Grade.Value == filter.GradeValue);
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
            catch (ArgumentNullException ex)
            {
                return (List<DbStudents>)Enumerable.Empty<DbStudents>();
            }
            catch (InvalidOperationException ex)
            {
                return (List<DbStudents>)Enumerable.Empty<DbStudents>();
            }
        }
    }
}
