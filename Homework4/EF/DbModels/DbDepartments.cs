using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DbModels
{
    public class DbDepartments
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<DbStudents> Students { get; set; }
        public ICollection<DbMentors> Mentors { get; set; }

        public DbDepartments()
        {
            Students = new HashSet<DbStudents>();
            Mentors = new HashSet<DbMentors>();
        }
    }

    public class DepartmentsConfiguration : IEntityTypeConfiguration<DbDepartments>
    {
        public void Configure(EntityTypeBuilder<DbDepartments> builder)
        {
            builder
                .ToTable("DbDepartments");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .HasMaxLength(150)
                .IsRequired();

            builder
                .HasMany(x => x.Students)
                .WithOne(x => x.Departments);

            builder
                .HasMany(x => x.Mentors)
                .WithOne(x => x.Departments);
        }
    }
}
