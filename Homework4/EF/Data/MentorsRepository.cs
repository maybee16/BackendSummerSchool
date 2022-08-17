using EF.Data.Interfaces;
using EF.DbModels;
using Microsoft.EntityFrameworkCore;
using WritelineLibrary;

namespace EF.Data
{
    public class MentorsRepository : IMentorsRepository
    {
        private readonly Context _context;

        public MentorsRepository()
        {
            _context = new Context();
        }

        public void Add(Mentors mentors)
        {
            try
            {
                Departments departments = _context.Departments.First(x => x.Name == mentors.Department);
                mentors.DepartmentsId = departments.Id;

                _context.Mentors.Add(mentors);
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

        public void GetMentor(Guid id)
        {
            try
            {
                Mentors mentor = _context.Mentors.First(x => x.Id == id);
                Mentors department = _context.Mentors.Include(x => x.Departments).First(x => x.Id == id);
                var studentsMentors = _context.StudentsMentors.Include(x => x.Students).Where(x => x.MentorsId == id);

                ColorMessage.Get("Id\tFirstName\tLastName\tPatronymic\tDepartment", ConsoleColor.Blue);
                ColorMessage.Get($"{mentor.Id}\t{mentor.FirstName}\t{mentor.LastName}\t" +
                        $"{mentor.Patronymic}\t{department.Departments.Name}", ConsoleColor.Green);

                // students list
                foreach (var student in studentsMentors)
                {
                    ColorMessage.Get($"Студент: {student.StudentsId}\t{student.Students.FirstName}\t" +
                        $"{student.Students.LastName}\t{student.Students.Patronymic}", ConsoleColor.Green);
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
                List<Mentors> mentors = _context.Mentors.ToList();

                ColorMessage.Get("Id\tFirstName\tLastName\tPatronymic\tDepartment", ConsoleColor.Blue);

                foreach (var mentor in mentors)
                {
                    ColorMessage.Get($"{mentor.Id}\t{mentor.FirstName}\t{mentor.LastName}\t" +
                        $"{mentor.Patronymic}\t{mentor.Department}", ConsoleColor.Green);
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
                Mentors mentors = _context.Mentors.First(x => x.Id == id);
                Departments departments = _context.Departments.First(x => x.Name == mentors.Department);

                mentors.FirstName = firstName;
                mentors.LastName = lastName;
                mentors.Patronymic = patronymic;
                mentors.Department = department;
                mentors.DepartmentsId = departments.Id;

                _context.Mentors.Update(mentors);
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
                Mentors mentor = _context.Mentors.First(x => x.Id == id);

                _context.Mentors.Remove(mentor);
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
