using GradeRequests;
using FluentValidation;

namespace ClientService.DepartmentValidations.Interfaces
{
    public interface IUpdateGradeRequestValidator : IValidator<UpdateGradeRequest>
    {
    }
}
