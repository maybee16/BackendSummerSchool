using EF.Data.Interfaces;
using EF.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritelineLibrary;

namespace EF.Data
{
    public class DepartmentsRepository : IDepartmentsRepository
    {
        private readonly Context _context;

        public DepartmentsRepository()
        {
            _context = new Context();
        }

        public void Add(Departments departments)
        {
            try
            {
                _context.Departments.Add(departments);
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

        public void GetDepartment(Guid id)
        {
            try
            {
                Departments department = _context.Departments.First(x => x.Id == id);

                ColorMessage.Get("Id\tName", ConsoleColor.Blue);
                ColorMessage.Get($"{department.Id}\t{department.Name}", ConsoleColor.Green);

                Departments students = _context.Departments.Include(x => x.Students).First(x => x.Id == id);
                Departments mentors = _context.Departments.Include(x => x.Mentors).First(x => x.Id == id);

                // get students list
                foreach (Students student in students.Students)
                {
                    ColorMessage.Get($"Student: {student.Id}\t{student.FirstName}\t{student.LastName}\t{student.Patronymic}", ConsoleColor.Green);
                }

                // get mentors list
                foreach (Mentors mentor in mentors.Mentors)
                {
                    ColorMessage.Get($"Mentor: {mentor.Id}\t{mentor.FirstName}\t{mentor.LastName}\t{mentor.Patronymic}", ConsoleColor.Green);
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
                List<Departments> departments = _context.Departments.ToList();

                ColorMessage.Get("Id\tName", ConsoleColor.Blue);

                foreach (var department in departments)
                {
                    ColorMessage.Get($"{department.Id}\t{department.Name}", ConsoleColor.Green);
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

        public void Update(Guid id, string name)
        {
            try
            {
                Departments department = _context.Departments.First(x => x.Id == id);

                department.Name = name;

                _context.Departments.Update(department);
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
                Departments department = _context.Departments.First(x => x.Id == id);

                _context.Departments.Remove(department);
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
