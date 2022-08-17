using ClientService.GradeRequests;
using ClientService.GradeResponses;

namespace ClientService.GradeCommands.Interfaces
{
    public interface IUpdateGradeCommand
    {
        UpdateGradeResponse Execute(UpdateGradeRequest request);
    }
}
