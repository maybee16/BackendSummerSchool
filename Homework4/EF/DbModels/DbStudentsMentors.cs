using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DbModels
{
    public class DbStudentsMentors
    {
        public Guid Id { get; set; }
        public Guid StudentsId { get; set; }
        public Guid MentorsId { get; set; }
        public DbStudents Students { get; set; }
        public DbMentors Mentors { get; set; }

        public DbStudentsMentors()
        {
            Students = new DbStudents();
            Mentors = new DbMentors();
        }
    }

    public class StudentsMentorsConfiguration : IEntityTypeConfiguration<DbStudentsMentors>
    {
        public void Configure(EntityTypeBuilder<DbStudentsMentors> builder)
        {
            builder
                .ToTable("DbStudentsMentors");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.StudentsId)
                .IsRequired();

            builder
                .Property(x => x.MentorsId)
                .IsRequired();

            builder
                .HasOne(x => x.Students)
                .WithMany(x => x.StudentsMentors);

            builder
                .HasOne(x => x.Mentors)
                .WithMany(x => x.StudentsMentors);
        }
    }
}
