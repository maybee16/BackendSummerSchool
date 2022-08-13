using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DbModels
{
    public class StudentsMentors
    {
        public Guid Id { get; set; }
        public Guid StudentsId { get; set; }
        public Guid MentorsId { get; set; }
        public Students Students { get; set; }
        public Mentors Mentors { get; set; }

        public StudentsMentors()
        {
            Students = new Students();
            Mentors = new Mentors();
        }
    }

    public class StudentsMentorsConfiguration : IEntityTypeConfiguration<StudentsMentors>
    {
        public void Configure(EntityTypeBuilder<StudentsMentors> builder)
        {
            builder
                .ToTable("StudentsMentors");

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
