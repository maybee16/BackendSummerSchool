using ClientService.Requests;
using ClientService.Responses;
using ClientService.StudentCommands.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;

namespace ClientService.StudentCommands
{
    public class CreateStudentCommand : ICreateStudentCommand
    {
        private readonly IValidator<CreateStudentRequest> _validator;

        public CreateStudentCommand(
            IValidator<CreateStudentRequest> validator)
        {
            _validator = validator;
        }

        public CreateStudentResponse Execute(CreateStudentRequest request)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new CreateStudentResponse
                {
                    Id = null,
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            return new CreateStudentResponse
            {
                Id = null,
                IsSuccess = true,
                Errors = default
            };
        }
    }
}
