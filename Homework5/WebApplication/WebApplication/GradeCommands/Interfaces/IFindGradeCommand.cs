using GradeRequests;
using SchoolModels;
using StudentResponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientService.GradeCommands.Interfaces
{
    public interface IFindGradeCommand
    {
        Task<BrokerResponse<List<GradeModel>>> ExecuteAsync(FindGradeRequest request);
    }
}
