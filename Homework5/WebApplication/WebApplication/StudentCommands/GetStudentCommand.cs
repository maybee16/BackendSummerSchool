using ClientService.Requests;
using ClientService.Responses;
using ClientService.StudentCommands.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;

namespace ClientService.StudentCommands
{
    public class GetStudentCommand : IGetStudentCommand
    {
        private readonly IValidator<GetStudentRequest> _validator;

        public GetStudentCommand(
            IValidator<GetStudentRequest> validator)
        {
            _validator = validator;
        }

        public GetStudentResponse Execute(GetStudentRequest request)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new GetStudentResponse
                {
                    FirstName = null,
                    LastName = null,
                    Patronymic = null,
                    Department = null,
                    Grade = null,
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            return new GetStudentResponse
            {
                // send to Server
                /*FirstName = _students.FirstName,
                LastName = _students.LastName,
                Patronymic = _students.Patronymic,
                Department = _students.Departments,
                Grade = _students.Grades,
                IsSuccess = false,
                Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()*/
            };
        }
    }
}
