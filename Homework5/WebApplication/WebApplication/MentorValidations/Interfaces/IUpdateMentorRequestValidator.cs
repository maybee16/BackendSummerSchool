using ClientService.MentorRequests;
using FluentValidation;

namespace ClientService.MentorValidations.Interfaces
{
    public interface IUpdateMentorRequestValidator : IValidator<UpdateMentorRequest>
    {
    }
}
