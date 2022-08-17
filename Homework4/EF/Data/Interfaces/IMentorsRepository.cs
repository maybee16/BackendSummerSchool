using EF.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data.Interfaces
{
    public interface IMentorsRepository
    {
        void Add(Mentors mentors);
        void GetMentor(Guid id);
        void Get();
        void Update(Guid id, string firstName, string lastName, string patronymic, string departments);
        void Find();
        void Delete(Guid id);
    }
}
