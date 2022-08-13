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
    public class GradesRepository
    {
        private readonly Context _context;

        public GradesRepository()
        {
            _context = new Context();
        }

        public void Add(Grades grades)
        {
            try
            {
                _context.Grades.Add(grades);
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

        public void GetGrade(Guid id)
        {
            try
            {
                Grades grade = _context.Grades.First(x => x.Id == id);
                Grades student = _context.Grades.Include(x => x.Student).First(x => x.Id == id);

                ColorMessage.Get("Id\tStudentId\tStudentFirstName\tStudentLastname\tStudentPatronymic\tValue", ConsoleColor.Blue);
                ColorMessage.Get($"{grade.Id}\t{grade.StudentId}\t{student.Student.FirstName}\t{student.Student.LastName}\t{student.Student.Patronymic}\t{grade.Value}", ConsoleColor.Green);
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
                List<Grades> grades = _context.Grades.ToList();

                ColorMessage.Get("Id\tStudentId\tValue", ConsoleColor.Blue);

                foreach (var grade in grades)
                {
                    ColorMessage.Get($"{grade.Id}\t{grade.StudentId}\t{grade.Value}", ConsoleColor.Green);
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

        public void Update(Guid id, Guid studentId, int value)
        {
            try
            {
                Grades grade = _context.Grades.First(x => x.Id == id);

                grade.StudentId = studentId;
                grade.Value = value;

                _context.Grades.Update(grade);
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
                Grades grade = _context.Grades.First(x => x.Id == id);

                _context.Grades.Remove(grade);
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
