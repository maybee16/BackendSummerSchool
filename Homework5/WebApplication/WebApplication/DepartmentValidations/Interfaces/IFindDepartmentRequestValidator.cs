using ClientService.DepartmentRequests;
using FluentValidation;

namespace ClientService.DepartmentValidations.Interfaces
{
    public interface IFindDepartmentRequestValidator : IValidator<FindDepartmentRequest>
    {
    }
}
