using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DbModels.Filters
{
    public class FindMentorsFilter
    {
        public string Department { get; set; }
        public string FirstNameContains { get; set; }
        public string LastNameContains { get; set; }
        public string PatronymicNameContains { get; set; }
        public int TakeCount { get; set; } = 1;
        public int SkipCount { get; set; } = 0;
    }
}
