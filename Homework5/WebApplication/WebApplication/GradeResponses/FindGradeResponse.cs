using ClientService.Models;
using System.Collections.Generic;

namespace ClientService.GradeResponses
{
    public class FindGradeResponse
    {
        public List<GradeModel> Grades { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
    }
}
