using MentorRequests;
using SchoolModels;
using StudentResponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientService.MentorCommands.Interfaces
{
    public interface IFindMentorCommand
    {
        Task<BrokerResponse<List<MentorModel>>> ExecuteAsync(FindMentorRequest request);
    }
}
