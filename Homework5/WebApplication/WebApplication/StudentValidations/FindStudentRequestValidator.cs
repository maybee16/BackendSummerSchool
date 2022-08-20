using ClientService.StudentValidations.Interfaces;
using FluentValidation;
using StudentRequests;

namespace ClientService.StudentValidations
{
    public class FindStudentRequestValidator : AbstractValidator<FindStudentRequest>, IFindStudentRequestValidator
    {
        public FindStudentRequestValidator()
        {
            When(request => !string.IsNullOrEmpty(request.Department),
                () =>
                RuleFor(request => request.Department)
                    .Must(d => d == "Frontend" || d == "frontend" || d == "Backend" || d == "backend")
                    .WithMessage("Invalid value for department"));

            When(request => request.GradeValue is not null,
                () =>
                RuleFor(request => request.GradeValue)
                    .Must(x => x >= 0 && x <= 5)
                    .WithMessage("Invalid value for grade"));

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
