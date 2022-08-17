using ClientService.Requests;
using FluentValidation;

namespace ClientService.StudentValidations.Interfaces
{
    public interface IGetStudentRequestValidator : IValidator<GetStudentRequest>
    {
    }
}
