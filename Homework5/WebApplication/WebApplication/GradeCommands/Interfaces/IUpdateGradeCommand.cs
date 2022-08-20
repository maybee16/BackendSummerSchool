using GradeRequests;
using StudentResponses;
using System;
using System.Threading.Tasks;

namespace ClientService.GradeCommands.Interfaces
{
    public interface IUpdateGradeCommand
    {
        Task<BrokerResponse<Guid?>> ExecuteAsync(UpdateGradeRequest request);
    }
}
