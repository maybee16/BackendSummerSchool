using ClientService.MentorRequests;
using ClientService.MentorResponses;

namespace ClientService.MentorCommands.Interfaces
{
    public interface ICreateMentorCommand
    {
        CreateMentorResponse Execute(CreateMentorRequest request);
    }
}
