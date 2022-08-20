using GradeRequests;
using StudentResponses;
using System;
using System.Threading.Tasks;

namespace ClientService.GradeCommands.Interfaces
{
    public interface ICreateGradeCommand
    {
        Task<BrokerResponse<Guid?>> ExecuteAsync(CreateGradeRequest request);
    }
}
