using ClientService.DepartmentRequests;
using ClientService.DepartmentValidations.Interfaces;
using FluentValidation;

namespace ClientService.DepartmentValidations
{
    public class GetDepartmentRequestValidator : AbstractValidator<GetDepartmentRequest>, IGetDepartmentRequestValidator
    {
        public GetDepartmentRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id can't be empty");
        }
    }
}
