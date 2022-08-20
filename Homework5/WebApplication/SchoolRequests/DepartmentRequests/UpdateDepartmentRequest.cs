using System;

namespace ClientService.DepartmentRequests
{
    public class UpdateDepartmentRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
