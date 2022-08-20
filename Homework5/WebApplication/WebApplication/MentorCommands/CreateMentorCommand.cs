using ClientService.MentorCommands.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MassTransit;
using MentorRequests;
using StudentResponses;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.MentorCommands
{
    public class CreateMentorCommand : ICreateMentorCommand
    {
        private readonly IValidator<CreateMentorRequest> _validator;
        private readonly IRequestClient<CreateMentorRequest> _requestClient;

        public CreateMentorCommand(
            IValidator<CreateMentorRequest> validator,
            IRequestClient<CreateMentorRequest> requestClient)
        {
            _validator = validator;
            _requestClient = requestClient;
        }

        public async Task<BrokerResponse<Guid?>> ExecuteAsync(CreateMentorRequest request)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new BrokerResponse<Guid?>
                {
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            var response = await _requestClient.GetResponse<BrokerResponse<Guid?>>(request);

            return response.Message;
        }
    }
}
