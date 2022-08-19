using ClientService.MentorValidations.Interfaces;
using FluentValidation;
using MentorRequests;

namespace ClientService.MentorValidations
{
    public class GetMentorRequestValidator : AbstractValidator<GetMentorRequest>, IGetMentorRequestValidator
    {
        public GetMentorRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id can't be empty");
        }
    }
}
