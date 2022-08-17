using ClientService.MentorCommands.Interfaces;
using ClientService.MentorRequests;
using ClientService.MentorResponses;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;

namespace ClientService.MentorCommands
{
    public class FindMentorCommand : IFindMentorCommand
    {
        private readonly IValidator<FindMentorRequest> _validator;

        public FindMentorCommand(
            IValidator<FindMentorRequest> validator)
        {
            _validator = validator;
        }

        public FindMentorResponse Execute(FindMentorRequest request)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new FindMentorResponse
                {
                    Students = null,
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            return new FindMentorResponse
            {
            };
        }
    }
}
