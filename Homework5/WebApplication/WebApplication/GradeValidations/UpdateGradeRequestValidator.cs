using ClientService.DepartmentValidations.Interfaces;
using ClientService.GradeRequests;
using FluentValidation;

namespace ClientService.GradeValidations
{
    public class UpdateGradeRequestValidator : AbstractValidator<UpdateGradeRequest>, IUpdateGradeRequestValidator
    {
        public UpdateGradeRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id can't be empty");

            RuleFor(request => request.StudentId)
                .NotEmpty()
                .WithMessage("Student Id can't be empty");

            RuleFor(request => request.Value)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Value can't be empty")
                .Must(x => x >= 0 && x <= 5)
                .WithMessage("Invalid value");
        }
    }
}
