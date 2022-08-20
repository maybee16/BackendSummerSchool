using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.DbModels
{
    public class DbStudents
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Patronymic { get; set; }
        public Guid DepartmentsId { get; set; }
        public string Department { get; set; }
        public ICollection<DbStudentsMentors> StudentsMentors { get; set; }
        public DbGrades Grade { get; set; }
        public DbDepartments Departments { get; set; }

        public DbStudents()
        {
            StudentsMentors = new HashSet<DbStudentsMentors>();
            Grade = new DbGrades();
            //Departments = new Departments();
        }
    }

    public class StudentsConfiguration : IEntityTypeConfiguration<DbStudents>
    {
        public void Configure(EntityTypeBuilder<DbStudents> builder)
        {
            builder
                .ToTable("DbStudents");

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

            builder
                .Property(x => x.Department)
                .HasMaxLength(8)
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
