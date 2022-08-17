using System;

namespace ClientService.Models
{
    public class GradeModel
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public int Value { get; set; }
    }
}
