using System;

namespace ClientService.GradeRequests
{
    public class CreateGradeRequest
    {
        public Guid StudentId { get; set; }
        public int Value { get; set; }
    }
}
