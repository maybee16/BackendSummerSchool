using EF.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    public interface IContext
    {
        public DbSet<Students> Students { get; set; }
        public DbSet<Mentors> Mentors { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<StudentsMentors> StudentsMentors { get; set; }

        public void SaveChanges();
    }
}
