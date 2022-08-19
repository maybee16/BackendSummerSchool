using MentorRequests;
using StudentResponses;
using System;
using System.Threading.Tasks;

namespace ClientService.MentorCommands.Interfaces
{
    public interface IUpdateMentorCommand
    {
        Task<BrokerResponse<Guid?>> ExecuteAsync(UpdateMentorRequest request);
    }
}
