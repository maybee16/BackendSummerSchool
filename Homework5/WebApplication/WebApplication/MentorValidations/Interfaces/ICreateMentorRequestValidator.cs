using FluentValidation;
using MentorRequests;

namespace ClientService.MentorValidations.Interfaces
{
    public interface ICreateMentorRequestValidator : IValidator<CreateMentorRequest>
    {
    }
}
