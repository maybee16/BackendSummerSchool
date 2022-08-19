using FluentValidation;
using StudentRequests;

namespace ClientService.StudentValidations.Interfaces
{
    public interface ICreateStudentRequestValidator : IValidator<CreateStudentRequest>
    {
    }
}
