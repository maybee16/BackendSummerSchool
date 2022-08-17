using FluentValidation;
using ClientService.Requests;

namespace ClientService.StudentValidations.Interfaces
{
    public interface ICreateStudentRequestValidator : IValidator<CreateStudentRequest>
    {
    }
}
