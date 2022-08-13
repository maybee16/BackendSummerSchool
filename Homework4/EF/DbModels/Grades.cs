using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DbModels
{
    public class Grades
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public int Value { get; set; }
        public Students Student { get; set; }

        //public Grades()
        //{
        //    Student = new Students();
        //}
    }

    public class GradesConfiguration : IEntityTypeConfiguration<Grades>
    {
        public void Configure(EntityTypeBuilder<Grades> builder)
        {
            builder
                .ToTable("Grades");

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
