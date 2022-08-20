using MentorRequests;
using FluentValidation;

namespace ClientService.MentorValidations.Interfaces
{
    public interface IGetMentorRequestValidator : IValidator<GetMentorRequest>
    {
    }
}
