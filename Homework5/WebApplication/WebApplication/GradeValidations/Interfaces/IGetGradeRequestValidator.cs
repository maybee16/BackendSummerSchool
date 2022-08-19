using GradeRequests;
using FluentValidation;

namespace ClientService.GradeValidations.Interfaces
{
    public interface IGetGradeRequestValidator : IValidator<GetGradeRequest>
    {
    }
}
