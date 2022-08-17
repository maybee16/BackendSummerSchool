using ClientService.Requests;
using ClientService.Responses;

namespace ClientService.StudentCommands.Interfaces
{
    public interface ICreateStudentCommand
    {
        CreateStudentResponse Execute(CreateStudentRequest request);
    }
}
