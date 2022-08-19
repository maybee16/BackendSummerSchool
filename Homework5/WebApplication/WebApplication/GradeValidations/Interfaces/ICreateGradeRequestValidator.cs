using GradeRequests;
using FluentValidation;

namespace ClientService.GradeValidations.Interfaces
{
    public interface ICreateGradeRequestValidator : IValidator<CreateGradeRequest>
    {
    }
}
