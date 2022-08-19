using Microsoft.EntityFrameworkCore;

namespace ClientService.Context
{
    public class DatabaseContext : DbContext
    {
        //public DbSet<Students> Students { get; set; }
        //public DbSet<Mentors> Mentors { get; set; }
        //public DbSet<Departments> Departments { get; set; }
        //public DbSet<Grades> Grades { get; set; }
        //public DbSet<StudentsMentors> StudentsMentors { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

    }
}
