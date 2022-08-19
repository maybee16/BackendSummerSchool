using FluentValidation;
using StudentRequests;

namespace ClientService.StudentValidations.Interfaces
{
    public interface IFindStudentRequestValidator : IValidator<FindStudentRequest>
    {
    }
}
