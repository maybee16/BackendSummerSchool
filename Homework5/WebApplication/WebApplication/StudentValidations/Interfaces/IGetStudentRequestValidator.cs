using FluentValidation;
using StudentRequests;

namespace ClientService.StudentValidations.Interfaces
{
    public interface IGetStudentRequestValidator : IValidator<GetStudentRequest>
    {
    }
}
