using ClientService.Models;
using System;
using System.Collections.Generic;

namespace ClientService.GradeResponses
{
    public class GetGradeResponse
    {
        public Guid? StudentId { get; set; }
        public int? Value { get; set; }
        public StudentModel Student { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
    }
}
