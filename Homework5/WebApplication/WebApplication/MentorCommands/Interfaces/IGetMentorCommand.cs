using MentorRequests;
using SchoolModels;
using StudentResponses;
using System.Threading.Tasks;

namespace ClientService.MentorCommands.Interfaces
{
    public interface IGetMentorCommand
    {
        Task<BrokerResponse<MentorModel>> ExecuteAsync(GetMentorRequest request);
    }
}
