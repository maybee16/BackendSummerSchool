using ClientService.DepartmentRequests;
using ClientService.DepartmentValidations.Interfaces;
using FluentValidation;

namespace ClientService.DepartmentValidations
{
    public class FindDepartmentRequestValidator : AbstractValidator<FindDepartmentRequest>, IFindDepartmentRequestValidator
    {
        public FindDepartmentRequestValidator()
        {
            RuleFor(request => request.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Name can't be empty")
                .Must(d => d == "Frontend" || d == "frontend" || d == "Backend" || d == "backend")
                .WithMessage("Invalid value");
        }
    }
}
