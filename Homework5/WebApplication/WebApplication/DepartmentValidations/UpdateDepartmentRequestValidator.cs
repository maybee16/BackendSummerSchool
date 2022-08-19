using ClientService.DepartmentRequests;
using ClientService.DepartmentValidations.Interfaces;
using FluentValidation;

namespace ClientService.DepartmentValidations
{
    public class UpdateDepartmentRequestValidator : AbstractValidator<UpdateDepartmentRequest>, IUpdateDepartmentRequestValidator
    {
        public UpdateDepartmentRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id can't be empty");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("First name can't be empty")
                .MinimumLength(2)
                .WithMessage("First name is too short")
                .MaximumLength(30)
                .WithMessage("First name is too long");
        }
    }
}
