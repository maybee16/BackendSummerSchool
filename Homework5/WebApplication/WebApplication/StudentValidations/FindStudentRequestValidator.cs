using ClientService.StudentRequests;
using ClientService.StudentValidations.Interfaces;
using FluentValidation;

namespace ClientService.StudentValidations
{
    public class FindStudentRequestValidator : AbstractValidator<FindStudentRequest>, IFindStudentRequestValidator
    {
        public FindStudentRequestValidator()
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
