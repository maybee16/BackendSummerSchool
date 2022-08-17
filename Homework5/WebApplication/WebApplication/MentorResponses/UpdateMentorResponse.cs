using System;
using System.Collections.Generic;

namespace ClientService.MentorResponses
{
    public class UpdateMentorResponse
    {
        public Guid? Id { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
    }
}
