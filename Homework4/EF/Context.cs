using EF.DbModels;
using Microsoft.EntityFrameworkCore;

namespace EF
{
    public class Context: DbContext, IContext
    {
        public DbSet<Students> Students { get; set; }
        public DbSet<Mentors> Mentors { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<StudentsMentors> StudentsMentors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=SchoolDB2;Trusted_Connection=True");
        }

        void IContext.SaveChanges()
        {
            SaveChanges();
        }
    }
}