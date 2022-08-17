using EF.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data.Interfaces
{
    internal interface IGradesRepository
    {
        void Add(Grades grades);
        void GetGrade(Guid id);
        void Get();
        void Update(Guid id, Guid studentId, int value);
        void Find();
        void Delete(Guid id);
    }
}
