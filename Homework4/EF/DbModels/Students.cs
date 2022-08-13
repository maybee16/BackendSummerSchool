using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.DbModels
{
    public class Students
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Patronymic { get; set; }
        public Guid DepartmentsId { get; set; }
        public ICollection<StudentsMentors> StudentsMentors { get; set; }
        public Grades Grade { get; set; }
        public Departments Departments { get; set; }

        public Students()
        {
            StudentsMentors = new HashSet<StudentsMentors>();
            Grade = new Grades();
            Departments = new Departments();
        }
    }

    public class StudentsConfiguration : IEntityTypeConfiguration<Students>
    {
        public void Configure(EntityTypeBuilder<Students> builder)
        {
            builder
                .ToTable("Students");

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
                .HasMaxLength(150)
                .IsRequired(false);

            builder
                .Property(x => x.DepartmentsId)
                .IsRequired();

            //builder
            //    .HasMany(x => x.StudentsMentors)
            //    .WithOne(x => x.Student);

            builder
                .HasOne(x => x.Grade)
                .WithOne(x => x.Student);
        }
    }
}
