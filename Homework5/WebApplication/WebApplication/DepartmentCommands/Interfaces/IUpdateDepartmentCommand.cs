using ClientService.DepartmentRequests;
using StudentResponses;
using System;
using System.Threading.Tasks;

namespace ClientService.DepartmentCommands.Interfaces
{
    public interface IUpdateDepartmentCommand
    {
        Task<BrokerResponse<Guid?>> ExecuteAsync(UpdateDepartmentRequest request);
    }
}
