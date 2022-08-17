using ClientService.MentorRequests;
using ClientService.MentorValidations.Interfaces;
using FluentValidation;

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
