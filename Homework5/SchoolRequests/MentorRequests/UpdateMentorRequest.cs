using System;

namespace MentorRequests
{
    public class UpdateMentorRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Department { get; set; }
    }
}
