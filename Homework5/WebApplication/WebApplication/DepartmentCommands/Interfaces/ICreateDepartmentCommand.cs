using ClientService.DepartmentRequests;
using StudentResponses;
using System;
using System.Threading.Tasks;

namespace ClientService.DepartmentCommands.Interfaces
{
    public interface ICreateDepartmentCommand
    {
        Task<BrokerResponse<Guid?>> ExecuteAsync(CreateDepartmentRequest request);
    }
}
