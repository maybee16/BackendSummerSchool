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
    public class UpdateMentorCommand : IUpdateMentorCommand
    {
        private readonly IValidator<UpdateMentorRequest> _validator;
        private readonly IRequestClient<UpdateMentorRequest> _requestClient;

        public UpdateMentorCommand(
            IValidator<UpdateMentorRequest> validator,
            IRequestClient<UpdateMentorRequest> requestClient)
        {
            _validator = validator;
            _requestClient = requestClient;
        }

        public async Task<BrokerResponse<Guid?>> ExecuteAsync(UpdateMentorRequest request)
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
