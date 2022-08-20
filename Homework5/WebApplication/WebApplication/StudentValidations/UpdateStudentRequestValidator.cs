using ClientService.StudentValidations.Interfaces;
using FluentValidation;
using StudentRequests;

namespace ClientService.StudentValidations
{
    public class UpdateStudentRequestValidator : AbstractValidator<UpdateStudentRequest>, IUpdateStudentRequestValidator
    {
        public UpdateStudentRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id can't be empty");

            RuleFor(x => x.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("First name can't be empty")
                .MinimumLength(2)
                .WithMessage("First name is too short")
                .MaximumLength(30)
                .WithMessage("First name is too long");

            RuleFor(request => request.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Last name can't be empty")
                .MinimumLength(2)
                .WithMessage("Last name is too short")
                .MaximumLength(30)
                .WithMessage("Last name is too long");

            When(request => !string.IsNullOrEmpty(request.Patronymic),
                () =>
                RuleFor(request => request.Patronymic)
                    .MinimumLength(2)
                    .WithMessage("Patronymic name is too short")
                    .MaximumLength(30)
                    .WithMessage("Patronymic name is too long"));

            RuleFor(request => request.Department)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Department can't be empty")
                .Must(d => d == "Frontend" || d == "frontend" || d == "Backend" || d == "backend")
                .WithMessage("Invalid value for department");
        }
    }
}
