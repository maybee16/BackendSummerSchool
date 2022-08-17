using System;
using System.Collections.Generic;

namespace ClientService.Responses
{
    public class CreateStudentResponse
    {
        public Guid? Id { get; set; }
        public bool IsSuccess { get; set; } 
        public List<string> Errors { get; set; }
    }
}
