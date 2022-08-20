using EF.DbModels;
using Microsoft.EntityFrameworkCore;

namespace EF
{
    public class Context: DbContext, IContext
    {
        public DbSet<DbStudents> DbStudents { get; set; }
        public DbSet<DbMentors> DbMentors { get; set; }
        public DbSet<DbDepartments> DbDepartments { get; set; }
        public DbSet<DbGrades> DbGrades { get; set; }
        public DbSet<DbStudentsMentors> DbStudentsMentors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=SchoolDB2;Trusted_Connection=True");
        }

        void IContext.SaveChangesAsync()
        {
            SaveChanges();
        }
    }
}