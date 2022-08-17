using System;
using System.Collections.Generic;

namespace ClientService.DepartmentResponses
{
    public class UpdateDepartmentResponse
    {
        public Guid? Id { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
    }
}
