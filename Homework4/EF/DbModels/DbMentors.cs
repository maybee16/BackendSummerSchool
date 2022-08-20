using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DbModels
{
    public class DbMentors
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Patronymic { get; set; }
        public Guid DepartmentsId { get; set; }
        public string Department { get; set; }
        public ICollection<DbStudentsMentors> StudentsMentors { get; set; }
        public DbDepartments Departments { get; set; }

        public DbMentors()
        {
            StudentsMentors = new HashSet<DbStudentsMentors>();
            //Departments = new DbDepartments();
        }
    }

    public class MentorsConfiguration : IEntityTypeConfiguration<DbMentors>
    {
        public void Configure(EntityTypeBuilder<DbMentors> builder)
        {
            builder
                .ToTable("DbMentors");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.FirstName)
                .HasMaxLength(150)
                .IsRequired();

            builder
                .Property(x => x.LastName)
                .HasMaxLength(150)
                .IsRequired();

            builder
                .Property(x => x.Patronymic)
                .HasMaxLength(150);

            builder
                .Property(x => x.DepartmentsId)
                .IsRequired();

            builder
                .Property(x => x.Department)
                .HasMaxLength(8)
                .IsRequired();

            //builder
            //    .HasMany(x => x.StudentsMentors)
            //    .WithOne(x => x.Mentor);
        }
    }
}
