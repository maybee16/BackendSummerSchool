using ClientService.GradeRequests;
using FluentValidation;

namespace ClientService.GradeValidations.Interfaces
{
    public interface IFindGradeRequestValidator : IValidator<FindGradeRequest>
    {
    }
}
