using ClientService.DepartmentRequests;
using ClientService.DepartmentResponses;
using ClientService.Requests;
using ClientService.Responses;

namespace ClientService.DepartmentCommands.Interfaces
{
    public interface ICreateDepartmentCommand
    {
        CreateDepartmentResponse Execute(CreateDepartmentRequest request);
    }
}
