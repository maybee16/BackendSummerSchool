using ClientService.MentorCommands.Interfaces;
using ClientService.MentorRequests;
using ClientService.MentorResponses;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;

namespace ClientService.MentorCommands
{
    public class GetMentorCommand : IGetMentorCommand
    {
        private readonly IValidator<GetMentorRequest> _validator;

        public GetMentorCommand(
            IValidator<GetMentorRequest> validator)
        {
            _validator = validator;
        }

        public GetMentorResponse Execute(GetMentorRequest request)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new GetMentorResponse
                {
                    FirstName = null,
                    LastName = null,
                    Patronymic = null,
                    Department = null,
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            return new GetMentorResponse
            {
                FirstName = null,
                LastName = null,
                Patronymic = null,
                Department = null,
                IsSuccess = true,
                Errors = default
            };
        }
    }
}
