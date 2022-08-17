using ClientService.GradeRequests;
using ClientService.GradeResponses;

namespace ClientService.GradeCommands.Interfaces
{
    public interface IFindGradeCommand
    {
        FindGradeResponse Execute(FindGradeRequest request);
    }
}
