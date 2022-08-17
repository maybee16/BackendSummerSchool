using ClientService.MentorRequests;
using ClientService.MentorValidations.Interfaces;
using FluentValidation;

namespace ClientService.MentorValidations
{
    public class FindMentorRequestValidator : AbstractValidator<FindMentorRequest>, IFindMentorRequestValidator
    {
        public FindMentorRequestValidator()
        {
            RuleFor(request => request.Department)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Department can't be empty")
                .Must(d => d == "Frontend" || d == "frontend" || d == "Backend" || d == "backend")
                .WithMessage("Invalid value");
        }
    }
}
