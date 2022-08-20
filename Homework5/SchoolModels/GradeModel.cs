using System;

namespace SchoolModels
{
    public record GradeModel
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public int Value { get; set; }
    }
}
