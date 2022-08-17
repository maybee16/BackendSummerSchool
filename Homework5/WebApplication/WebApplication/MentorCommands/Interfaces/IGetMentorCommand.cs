using ClientService.MentorRequests;
using ClientService.MentorResponses;

namespace ClientService.MentorCommands.Interfaces
{
    public interface IGetMentorCommand
    {
        GetMentorResponse Execute(GetMentorRequest request);
    }
}
