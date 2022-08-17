using ClientService.GradeRequests;
using ClientService.GradeValidations.Interfaces;
using FluentValidation;

namespace ClientService.GradeValidations
{
    public class GetGradeRequestValidator : AbstractValidator<GetGradeRequest>, IGetGradeRequestValidator
    {
        public GetGradeRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id can't be empty");
        }
    }
}
