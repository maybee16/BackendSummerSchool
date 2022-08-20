using ClientService.DepartmentRequests;
using ClientService.DepartmentValidations.Interfaces;
using FluentValidation;

namespace ClientService.DepartmentValidations
{
    public class CreateDepartmentRequestValidator : AbstractValidator<CreateDepartmentRequest>, ICreateDepartmentRequestValidator
    {
        public CreateDepartmentRequestValidator()
        {
            RuleFor(request => request.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Name can't be empty")
                .MinimumLength(2)
                .WithMessage("Name is too short")
                .MaximumLength(30)
                .WithMessage("Name is too long");
        }
    }
}
