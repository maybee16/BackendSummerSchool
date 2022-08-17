using ClientService.StudentRequests;
using ClientService.StudentResponses;

namespace ClientService.StudentCommands.Interfaces
{
    public interface IFindStudentCommand
    {
        FindStudentResponse Execute(FindStudentRequest request);
    }
}
