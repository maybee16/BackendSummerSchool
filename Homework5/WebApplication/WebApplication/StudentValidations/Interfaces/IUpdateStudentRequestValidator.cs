using FluentValidation;
using StudentRequests;

namespace ClientService.StudentValidations.Interfaces
{
    public interface IUpdateStudentRequestValidator : IValidator<UpdateStudentRequest>
    {
    }
}
