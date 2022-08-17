using ClientService.DepartmentRequests;
using ClientService.DepartmentValidations.Interfaces;
using ClientService.GradeRequests;
using ClientService.GradeValidations.Interfaces;
using FluentValidation;

namespace ClientService.GradeValidations
{
    public class FindGradeRequestValidator : AbstractValidator<FindGradeRequest>, IFindGradeRequestValidator
    {
        public FindGradeRequestValidator()
        {
            RuleFor(request => request.Value)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Value can't be empty")
                .Must(x => x >= 0 && x <= 5)
                .WithMessage("Invalid value");
        }
    }
}
