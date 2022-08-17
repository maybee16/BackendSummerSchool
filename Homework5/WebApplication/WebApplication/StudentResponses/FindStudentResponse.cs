using ClientService.Models;
using System.Collections.Generic;

namespace ClientService.StudentResponses
{
    public class FindStudentResponse
    {
        public List<StudentModel> Students { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
    }
}
