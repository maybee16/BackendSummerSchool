using GradeRequests;
using ClientService.GradeValidations.Interfaces;
using FluentValidation;

namespace ClientService.GradeValidations
{
    public class FindGradeRequestValidator : AbstractValidator<FindGradeRequest>, IFindGradeRequestValidator
    {
        public FindGradeRequestValidator()
        {
            When(request => request.Value is not null,
                () =>
                RuleFor(request => request.Value)
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
