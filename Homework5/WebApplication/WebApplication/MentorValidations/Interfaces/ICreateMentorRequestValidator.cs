using ClientService.MentorRequests;
using FluentValidation;

namespace ClientService.MentorValidations.Interfaces
{
    public interface ICreateMentorRequestValidator : IValidator<CreateMentorRequest>
    {
    }
}
