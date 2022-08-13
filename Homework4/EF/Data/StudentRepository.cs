using EF.DbModels;
using Microsoft.EntityFrameworkCore;
using WritelineLibrary;

namespace EF.Data
{
    public class StudentRepository
    {
        private readonly Context _context;

        public StudentRepository()
        {
            _context = new Context();
        }

        public void Add(Students students)
        {
            try
            {
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
        }

        public void GetStudent(Guid id)
        {
            try
            {
                Students student = _context.Students.First(x => x.Id == id);
                Students department = _context.Students.Include(x => x.Departments).First(x => x.Id == id);
                Students grade = _context.Students.Include(x => x.Grade).First(x => x.Id == id);
                var studentsMentors = _context.StudentsMentors.Include(x => x.Mentors).Where(x => x.StudentsId == id);

                ColorMessage.Get("Id\tFirstName\tLastName\tPatronymic\tDepartment\tGrade", ConsoleColor.Blue);
                ColorMessage.Get($"{student.Id}\t{student.FirstName}\t{student.LastName}\t" +
                        $"{student.Patronymic}\t{department.Departments.Name}\t{grade.Grade.Value}", ConsoleColor.Green);

                // mentors list
                foreach (var mentor in studentsMentors)
                {
                    ColorMessage.Get($"Ментор: {mentor.MentorsId}\t{mentor.Mentors.FirstName}\t" +
                        $"{mentor.Mentors.LastName}\t{mentor.Mentors.Patronymic}", ConsoleColor.Green);
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

        public void Get()
        {
            try
            {
                List<Students> students = _context.Students.ToList();

                ColorMessage.Get("Id\tFirstName\tLastName\tPatronymic\tDepartmentId", ConsoleColor.Blue);

                foreach (var student in students)
                {
                    ColorMessage.Get($"{student.Id}\t{student.FirstName}\t{student.LastName}\t" +
                        $"{student.Patronymic}\t{student.DepartmentsId}", ConsoleColor.Green);
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

        public void Update(Guid id, string firstName, string lastName, string patronymic, Guid departmentsId)
        {
            try
            {
                Students student = _context.Students.First(x => x.Id == id);

                student.FirstName = firstName;
                student.LastName = lastName;
                student.Patronymic = patronymic;
                student.DepartmentsId = departmentsId;

                _context.Students.Update(student);
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
    }
}
