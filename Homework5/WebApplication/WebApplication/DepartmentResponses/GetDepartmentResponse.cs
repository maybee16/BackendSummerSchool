using ClientService.Models;
using System.Collections.Generic;

namespace ClientService.DepartmentResponses
{
    public class GetDepartmentResponse
    {
        public string Name { get; set; }
        public List<StudentModel> Students { get; set; }
        public List<MentorModel> Mentors { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
    }
}
