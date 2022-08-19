using MentorRequests;
using StudentResponses;
using System;
using System.Threading.Tasks;

namespace ClientService.MentorCommands.Interfaces
{
    public interface ICreateMentorCommand
    {
        Task<BrokerResponse<Guid?>> ExecuteAsync(CreateMentorRequest request);
    }
}
