using StudentRequests;
using StudentResponses;
using System;
using System.Threading.Tasks;

namespace ClientService.StudentCommands.Interfaces
{
    public interface ICreateStudentCommand
    {
        Task<BrokerResponse<Guid?>> ExecuteAsync(CreateStudentRequest request);
    }
}
