using ClientService.StudentValidations.Interfaces;
using FluentValidation;
using StudentRequests;

namespace ClientService.StudentValidations
{
    public class GetStudentRequestValidator : AbstractValidator<GetStudentRequest>, IGetStudentRequestValidator
    {
        public GetStudentRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id can't be empty");
        }
    }
}
