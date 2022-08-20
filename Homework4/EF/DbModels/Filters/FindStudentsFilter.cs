using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DbModels.Filters
{
    public class FindStudentsFilter
    {
        public string Department { get; set; }
        public int? GradeValue { get; set; } = 5;
        //public bool IncludeGrade { get; set; } = false;
        public string FirstNameContains { get; set; }
        public string LastNameContains { get; set; }
        public string PatronymicNameContains { get; set; }
        public int TakeCount { get; set; } = 1;
        public int SkipCount { get; set; } = 0;
    }
}
