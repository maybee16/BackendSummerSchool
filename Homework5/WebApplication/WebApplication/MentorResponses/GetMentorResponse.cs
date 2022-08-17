using ClientService.Models;
using System.Collections.Generic;

namespace ClientService.MentorResponses
{
    public class GetMentorResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DepartmentModel Department { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
    }
}
