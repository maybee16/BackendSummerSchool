using EF.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data.Interfaces
{
    public interface IStudentsRepository
    {
        Guid Add(Students students);
        Students GetStudent(Guid id);
        void Get();
        void Update(Guid id, string firstName, string lastName, string patronymic, string department);
        void Find();
        void Delete(Guid id);
    }
}
