using ClientService.DepartmentRequests;
using ClientService.DepartmentValidations.Interfaces;
using FluentValidation;

namespace ClientService.DepartmentValidations
{
    public class FindDepartmentRequestValidator : AbstractValidator<FindDepartmentRequest>, IFindDepartmentRequestValidator
    {
        public FindDepartmentRequestValidator()
        {
            When(request => !string.IsNullOrEmpty(request.NameContains),
                () =>
                RuleFor(request => request.NameContains)
                    .MaximumLength(10)
                    .WithMessage("Invalid value for name"));

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
