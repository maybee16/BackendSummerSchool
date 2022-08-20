using MentorRequests;
using ClientService.MentorValidations.Interfaces;
using FluentValidation;

namespace ClientService.MentorValidations
{
    public class FindMentorRequestValidator : AbstractValidator<FindMentorRequest>, IFindMentorRequestValidator
    {
        public FindMentorRequestValidator()
        {
            When(request => !string.IsNullOrEmpty(request.Department),
                () =>
                RuleFor(request => request.Department)
                    .Must(d => d == "Frontend" || d == "frontend" || d == "Backend" || d == "backend")
                    .WithMessage("Invalid value for department"));

            When(request => request.SkipCount is not null,
                () =>
                RuleFor(request => request.SkipCount)
                    .Must(x => x >= 0)
                    .WithMessage("Invalid value for skip count"));

            When(request => request.TakeCount is not null,
                () =>
                RuleFor(request => request.TakeCount)
                    .Must(x => x >= 0)
                    .WithMessage("Invalid value for take count"));
        }
    }
}
