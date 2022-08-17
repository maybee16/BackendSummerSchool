using System;
using System.Collections.Generic;

namespace ClientService.MentorResponses
{
    public class CreateMentorResponse
    {
        public Guid? Id { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
    }
}
