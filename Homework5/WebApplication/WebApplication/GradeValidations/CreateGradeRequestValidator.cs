using GradeRequests;
using ClientService.GradeValidations.Interfaces;
using FluentValidation;

namespace ClientService.GradeValidations
{
    public class CreateGradeRequestValidator : AbstractValidator<CreateGradeRequest>, ICreateGradeRequestValidator
    {
        public CreateGradeRequestValidator()
        {
            RuleFor(request => request.StudentId)
                .NotEmpty()
                .WithMessage("Student Id can't be empty");

            RuleFor(request => request.Value)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Value can't be empty")
                .Must(x => x >= 0 && x <= 5)
                .WithMessage("Invalid value for grade");
        }
    }
}
