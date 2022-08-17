using ClientService.MentorRequests;
using ClientService.MentorResponses;

namespace ClientService.MentorCommands.Interfaces
{
    public interface IUpdateMentorCommand
    {
        UpdateMentorResponse Execute(UpdateMentorRequest request);
    }
}
