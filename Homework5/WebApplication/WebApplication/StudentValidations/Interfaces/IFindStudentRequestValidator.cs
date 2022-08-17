using ClientService.StudentRequests;
using FluentValidation;

namespace ClientService.StudentValidations.Interfaces
{
    public interface IFindStudentRequestValidator : IValidator<FindStudentRequest>
    {
    }
}
