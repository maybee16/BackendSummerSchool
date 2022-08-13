using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DbModels
{
    public class Departments
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Students> Students { get; set; }
        public ICollection<Mentors> Mentors { get; set; }

        public Departments()
        {
            Students = new HashSet<Students>();
            Mentors = new HashSet<Mentors>();
        }
    }

    public class DepartmentsConfiguration : IEntityTypeConfiguration<Departments>
    {
        public void Configure(EntityTypeBuilder<Departments> builder)
        {
            builder
                .ToTable("Departments");

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
