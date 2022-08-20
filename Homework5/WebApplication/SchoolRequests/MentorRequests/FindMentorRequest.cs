namespace MentorRequests
{
    public class FindMentorRequest
    {
        public string Department { get; set; }
        public string FirstNameContains { get; set; }
        public string LastNameContains { get; set; }
        public string PatronymicNameContains { get; set; }
        public int? TakeCount { get; set; }
        public int? SkipCount { get; set; }
    }
}
