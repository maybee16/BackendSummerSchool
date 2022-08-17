using ClientService.MentorRequests;
using ClientService.MentorResponses;

namespace ClientService.MentorCommands.Interfaces
{
    public interface IFindMentorCommand
    {
        FindMentorResponse Execute(FindMentorRequest request);
    }
}
