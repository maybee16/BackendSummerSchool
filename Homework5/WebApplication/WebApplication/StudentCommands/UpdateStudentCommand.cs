using ClientService.StudentCommands.Interfaces;
using ClientService.StudentRequests;
using ClientService.StudentResponses;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;

namespace ClientService.StudentCommands
{
    public class UpdateStudentCommand : IUpdateStudentCommand
    {
        private readonly IValidator<UpdateStudentRequest> _validator;

        public UpdateStudentCommand(
            IValidator<UpdateStudentRequest> validator)
        {
            _validator = validator;
        }

        public UpdateStudentResponse Execute(UpdateStudentRequest request)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new UpdateStudentResponse
                {
                    Id = null,
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            return new UpdateStudentResponse
            {

            };
        }
    }
}
