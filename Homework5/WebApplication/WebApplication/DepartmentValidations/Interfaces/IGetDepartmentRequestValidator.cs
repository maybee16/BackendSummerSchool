using ClientService.DepartmentRequests;
using ClientService.Requests;
using FluentValidation;

namespace ClientService.DepartmentValidations.Interfaces
{
    public interface IGetDepartmentRequestValidator : IValidator<GetDepartmentRequest>
    {
    }
}
