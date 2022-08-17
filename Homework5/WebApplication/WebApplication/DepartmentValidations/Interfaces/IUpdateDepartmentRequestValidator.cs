using ClientService.DepartmentRequests;
using ClientService.StudentRequests;
using FluentValidation;

namespace ClientService.DepartmentValidations.Interfaces
{
    public interface IUpdateDepartmentRequestValidator : IValidator<UpdateDepartmentRequest>
    {
    }
}
