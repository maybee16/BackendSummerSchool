using ClientService.GradeRequests;
using ClientService.GradeResponses;

namespace ClientService.GradeCommands.Interfaces
{
    public interface IGetGradeCommand
    {
        GetGradeResponse Execute(GetGradeRequest request);
    }
}
