using EF.Data.Interfaces;
using EF.DbModels;
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

        public Guid Add(Students students)
        {
            try
            {
                Departments departments = _context.Departments.First(x => x.Name == students.Department);
                students.DepartmentsId = departments.Id;

                _context.Students.Add(students);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ColorMessage.Get(ex.Message, ConsoleColor.Red);
            }
            catch (DbUpdateException ex)
            {
                ColorMessage.Get(ex.Message, ConsoleColor.Red);
            }

            ColorMessage.Get("Объект добавлен", ConsoleColor.Green);

            return students.Id;
        }

        public Students GetStudent(Guid id)
        {
            try
            {
                Students student = _context.Students.Include(x => x.Departments).Include(x => x.Grade).Include(x => x.StudentsMentors).First(x => x.Id == id);

                ColorMessage.Get("Id\tFirstName\tLastName\tPatronymic\tDepartment\tGrade", ConsoleColor.Blue);
                ColorMessage.Get($"{student.Id}\t{student.FirstName}\t{student.LastName}\t" +
                        $"{student.Patronymic}\t{student.Departments.Name}\t{student.Grade.Value}", ConsoleColor.Green);

                // mentors list don't output 
                foreach (var mentor in student.StudentsMentors.Where(x => x.StudentsId == id))
                {
                    ColorMessage.Get($"Ментор: {mentor.MentorsId}\t{mentor.Mentors.FirstName}\t" +
                        $"{mentor.Mentors.LastName}\t{mentor.Mentors.Patronymic}", ConsoleColor.Green);
                }

                return student;
            }
            catch (ArgumentNullException ex)
            {
                ColorMessage.Get(ex.Message, ConsoleColor.Red);
            }
            catch (InvalidOperationException ex)
            {
                ColorMessage.Get(ex.Message, ConsoleColor.Red);
            }
            
            return null;
        }

        public void Get()
        {
            try
            {
                List<Students> students = _context.Students.ToList();

                ColorMessage.Get("Id\tFirstName\tLastName\tPatronymic\tDepartment", ConsoleColor.Blue);

                foreach (var student in students)
                {
                    ColorMessage.Get($"{student.Id}\t{student.FirstName}\t{student.LastName}\t" +
                        $"{student.Patronymic}\t{student.Department}", ConsoleColor.Green);
                }
            }
            catch (ArgumentNullException ex)
            {
                ColorMessage.Get(ex.Message, ConsoleColor.Red);
            }
            catch (InvalidOperationException ex)
            {
                ColorMessage.Get(ex.Message, ConsoleColor.Red);
            }
        }

        public void Update(Guid id, string firstName, string lastName, string patronymic, string department)
        {
            try
            {
                Students students = _context.Students.First(x => x.Id == id);

                Departments departments = _context.Departments.First(x => x.Name == students.Department);

                students.FirstName = firstName;
                students.LastName = lastName;
                students.Patronymic = patronymic;
                students.DepartmentsId = departments.Id;
                students.Departments = departments;

                _context.Students.Update(students);
                _context.SaveChanges();
            }
            catch (ArgumentNullException ex)
            {
                ColorMessage.Get(ex.Message, ConsoleColor.Red);
            }
            catch (InvalidOperationException ex)
            {
                ColorMessage.Get(ex.Message, ConsoleColor.Red);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ColorMessage.Get(ex.Message, ConsoleColor.Red);
            }
            catch (DbUpdateException ex)
            {
                ColorMessage.Get(ex.Message, ConsoleColor.Red);
            }

            ColorMessage.Get("Объект обновлён", ConsoleColor.Green);
        }

        public void Delete(Guid id)
        {
            try
            {
                Students student = _context.Students.First(x => x.Id == id);

                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            catch (ArgumentNullException ex)
            {
                ColorMessage.Get(ex.Message, ConsoleColor.Red);
            }
            catch (InvalidOperationException ex)
            {
                ColorMessage.Get(ex.Message, ConsoleColor.Red);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ColorMessage.Get(ex.Message, ConsoleColor.Red);
            }
            catch (DbUpdateException ex)
            {
                ColorMessage.Get(ex.Message, ConsoleColor.Red);
            }

            ColorMessage.Get("Объект удалён", ConsoleColor.Green);
        }

        public void Find()
        {
            throw new NotImplementedException();
        }
    }
}
