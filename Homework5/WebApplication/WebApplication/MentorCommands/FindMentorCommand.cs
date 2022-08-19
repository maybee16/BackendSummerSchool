using ClientService.MentorCommands.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MassTransit;
using MentorRequests;
using SchoolModels;
using StudentResponses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.MentorCommands
{
    public class FindMentorCommand : IFindMentorCommand
    {
        private readonly IValidator<FindMentorRequest> _validator;
        private readonly IRequestClient<FindMentorRequest> _requestClient;

        public FindMentorCommand(
            IValidator<FindMentorRequest> validator,
            IRequestClient<FindMentorRequest> requestClient)
        {
            _validator = validator;
            _requestClient = requestClient;
        }

        public async Task<BrokerResponse<List<MentorModel>>> ExecuteAsync(FindMentorRequest request)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new BrokerResponse<List<MentorModel>>
                {
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            var response = await _requestClient.GetResponse<BrokerResponse<List<MentorModel>>>(request);

            return response.Message;
        }
    }
}
