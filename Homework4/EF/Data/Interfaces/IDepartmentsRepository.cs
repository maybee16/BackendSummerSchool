using EF.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data.Interfaces
{
    internal interface IDepartmentsRepository
    {
        void Add(Departments departments);
        void GetDepartment(Guid id);
        void Get();
        void Update(Guid id, string name);
        void Find();
        void Delete(Guid id);
    }
}
