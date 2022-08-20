using ClientService.DepartmentRequests;
using SchoolModels;
using StudentResponses;
using System.Threading.Tasks;

namespace ClientService.DepartmentCommands.Interfaces
{
    public interface IGetDepartmentCommand
    {
        Task<BrokerResponse<DepartmentModel>> ExecuteAsync(GetDepartmentRequest request);
    }
}
