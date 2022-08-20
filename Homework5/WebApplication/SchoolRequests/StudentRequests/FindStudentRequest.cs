namespace StudentRequests
{
    public class FindStudentRequest
    {
        public string Department { get; set; }
        public int? GradeValue { get; set; }
        public string FirstNameContains { get; set; }
        public string LastNameContains { get; set; }
        public string PatronymicNameContains { get; set; }
        public int? TakeCount { get; set; }
        public int? SkipCount { get; set; }
    }
}
