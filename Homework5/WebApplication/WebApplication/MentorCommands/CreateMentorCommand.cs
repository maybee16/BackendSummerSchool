using ClientService.MentorCommands.Interfaces;
using ClientService.MentorRequests;
using ClientService.MentorResponses;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;

namespace ClientService.MentorCommands
{
    public class CreateMentorCommand : ICreateMentorCommand
    {
        private readonly IValidator<CreateMentorRequest> _validator;

        public CreateMentorCommand(
            IValidator<CreateMentorRequest> validator)
        {
            _validator = validator;
        }

        public CreateMentorResponse Execute(CreateMentorRequest request)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new CreateMentorResponse
                {
                    Id = null,
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            return new CreateMentorResponse
            {
                Id = null,
                IsSuccess = true,
                Errors = default
            };
        }
    }
}
