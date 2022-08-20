using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DbModels
{
    public class DbGrades
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public int Value { get; set; }
        public DbStudents Student { get; set; }

        //public Grades()
        //{
        //    Student = new Students();
        //}
    }

    public class GradesConfiguration : IEntityTypeConfiguration<DbGrades>
    {
        public void Configure(EntityTypeBuilder<DbGrades> builder)
        {
            builder
                .ToTable("DbGrades");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.StudentId)
                .IsRequired();

            builder
                .Property(x => x.Value)
                .HasMaxLength(1)
                .IsRequired();
        }
    }
}
