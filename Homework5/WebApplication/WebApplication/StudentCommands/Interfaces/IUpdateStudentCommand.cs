using StudentRequests;
using StudentResponses;
using System;
using System.Threading.Tasks;

namespace ClientService.StudentCommands.Interfaces
{
    public interface IUpdateStudentCommand
    {
        Task<BrokerResponse<Guid?>> ExecuteAsync(UpdateStudentRequest request);
    }
}
