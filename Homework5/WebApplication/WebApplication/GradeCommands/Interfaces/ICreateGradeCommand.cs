using ClientService.GradeRequests;
using ClientService.GradeResponses;

namespace ClientService.GradeCommands.Interfaces
{
    public interface ICreateGradeCommand
    {
        CreateGradeResponse Execute(CreateGradeRequest request);
    }
}
