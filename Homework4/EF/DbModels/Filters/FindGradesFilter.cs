using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DbModels.Filters
{
    public class FindGradesFilter
    {
        public int? Value { get; set; } = 5;
        public int TakeCount { get; set; } = 1;
        public int SkipCount { get; set; } = 0;
    }
}
