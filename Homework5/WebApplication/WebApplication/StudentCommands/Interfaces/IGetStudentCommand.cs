using ClientService.Requests;
using ClientService.Responses;

namespace ClientService.StudentCommands.Interfaces
{
    public interface IGetStudentCommand
    {
        GetStudentResponse Execute(GetStudentRequest request);
    }
}
