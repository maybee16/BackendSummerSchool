using ClientService.StudentCommands.Interfaces;
using ClientService.StudentRequests;
using ClientService.StudentResponses;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;

namespace ClientService.StudentCommands
{
    public class FindStudentCommand : IFindStudentCommand
    {
        private readonly IValidator<FindStudentRequest> _validator;

        public FindStudentCommand(
            IValidator<FindStudentRequest> validator)
        {
            _validator = validator;
        }

        public FindStudentResponse Execute(FindStudentRequest request)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new FindStudentResponse
                {
                    Students = null,
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            return new FindStudentResponse
            {
                Students = null,
                IsSuccess = true,
                Errors = default
            };
        }
    }
}
