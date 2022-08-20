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
        public DbSet<DbStudents> DbStudents { get; set; }
        public DbSet<DbMentors> DbMentors { get; set; }
        public DbSet<DbDepartments> DbDepartments { get; set; }
        public DbSet<DbGrades> DbGrades { get; set; }
        public DbSet<DbStudentsMentors> DbStudentsMentors { get; set; }

        public void SaveChangesAsync();
    }
}
