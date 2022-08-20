namespace ClientService.DepartmentRequests
{
    public class FindDepartmentRequest
    {
        public string NameContains { get; set; }
        public int? TakeCount { get; set; }
        public int? SkipCount { get; set; }
    }
}
