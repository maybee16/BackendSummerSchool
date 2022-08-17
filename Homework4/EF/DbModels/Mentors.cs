using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DbModels
{
    public class Mentors
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Patronymic { get; set; }
        public Guid DepartmentsId { get; set; }
        public string Department { get; set; }
        public ICollection<StudentsMentors> StudentsMentors { get; set; }
        public Departments Departments { get; set; }

        public Mentors()
        {
            StudentsMentors = new HashSet<StudentsMentors>();
            Departments = new Departments();
        }
    }

    public class MentorsConfiguration : IEntityTypeConfiguration<Mentors>
    {
        public void Configure(EntityTypeBuilder<Mentors> builder)
        {
            builder
                .ToTable("Mentors");

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
