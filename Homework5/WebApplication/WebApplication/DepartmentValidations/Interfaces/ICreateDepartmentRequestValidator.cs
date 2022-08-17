using FluentValidation;
using ClientService.Requests;
using ClientService.DepartmentRequests;

namespace ClientService.DepartmentValidations.Interfaces
{
    public interface ICreateDepartmentRequestValidator : IValidator<CreateDepartmentRequest>
    {
    }
}
