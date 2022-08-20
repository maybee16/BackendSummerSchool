using ClientService.MentorCommands.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MassTransit;
using MentorRequests;
using SchoolModels;
using StudentResponses;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.MentorCommands
{
    public class GetMentorCommand : IGetMentorCommand
    {
        private readonly IValidator<GetMentorRequest> _validator;
        private readonly IRequestClient<GetMentorRequest> _requestClient;

        public GetMentorCommand(
            IValidator<GetMentorRequest> validator,
            IRequestClient<GetMentorRequest> requestClient)
        {
            _validator = validator;
            _requestClient = requestClient;
        }

        public async Task<BrokerResponse<MentorModel>> ExecuteAsync(GetMentorRequest request)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new BrokerResponse<MentorModel>
                {
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            var response = await _requestClient.GetResponse<BrokerResponse<MentorModel>>(request);

            return response.Message;
        }
    }
}
