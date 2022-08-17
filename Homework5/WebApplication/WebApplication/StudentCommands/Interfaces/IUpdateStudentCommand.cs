using ClientService.StudentRequests;
using ClientService.StudentResponses;

namespace ClientService.StudentCommands.Interfaces
{
    public interface IUpdateStudentCommand
    {
        UpdateStudentResponse Execute(UpdateStudentRequest request);
    }
}
