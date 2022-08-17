using ClientService.MentorCommands.Interfaces;
using ClientService.MentorRequests;
using ClientService.MentorResponses;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;

namespace ClientService.MentorCommands
{
    public class UpdateMentorCommand : IUpdateMentorCommand
    {
        private readonly IValidator<UpdateMentorRequest> _validator;

        public UpdateMentorCommand(
            IValidator<UpdateMentorRequest> validator)
        {
            _validator = validator;
        }

        public UpdateMentorResponse Execute(UpdateMentorRequest request)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new UpdateMentorResponse
                {
                    Id = null,
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            return new UpdateMentorResponse
            {
                Id = null,
                IsSuccess = true,
                Errors = default
            };
        }
    }
}
