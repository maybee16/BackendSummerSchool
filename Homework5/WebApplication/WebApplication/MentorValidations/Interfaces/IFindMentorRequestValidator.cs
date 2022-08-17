using ClientService.MentorRequests;
using FluentValidation;

namespace ClientService.MentorValidations.Interfaces
{
    public interface IFindMentorRequestValidator : IValidator<FindMentorRequest>
    {
    }
}
