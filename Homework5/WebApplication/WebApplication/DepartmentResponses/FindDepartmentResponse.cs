using ClientService.Models;
using System.Collections.Generic;

namespace ClientService.DepartmentResponses
{
    public class FindDepartmentResponse
    {
        public List<DepartmentModel> Departments { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
    }
}
