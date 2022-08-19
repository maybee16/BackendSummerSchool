using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DbModels.Filters
{
    public class FindDepartmentsFilter
    {
        public string NameContains { get; set; }
        public int TakeCount { get; set; } = 1;
        public int SkipCount { get; set; } = 0;
    }
}
