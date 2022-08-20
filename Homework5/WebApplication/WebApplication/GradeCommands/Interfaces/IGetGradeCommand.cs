using GradeRequests;
using SchoolModels;
using StudentResponses;
using System.Threading.Tasks;

namespace ClientService.GradeCommands.Interfaces
{
    public interface IGetGradeCommand
    {
        Task<BrokerResponse<GradeModel>> ExecuteAsync(GetGradeRequest request);
    }
}
