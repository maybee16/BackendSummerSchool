using ClientService.DepartmentRequests;
using SchoolModels;
using StudentResponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientService.DepartmentCommands.Interfaces
{
    public interface IFindDepartmentCommand
    {
        Task<BrokerResponse<List<DepartmentModel>>> ExecuteAsync(FindDepartmentRequest request);
    }
}
