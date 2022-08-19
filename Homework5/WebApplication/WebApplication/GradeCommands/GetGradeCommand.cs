using ClientService.GradeCommands.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using GradeRequests;
using MassTransit;
using SchoolModels;
using StudentResponses;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.GradeCommands
{
    public class GetGradeCommand : IGetGradeCommand
    {
        private readonly IValidator<GetGradeRequest> _validator;
        private readonly IRequestClient<GetGradeRequest> _requestClient;

        public GetGradeCommand(
            IValidator<GetGradeRequest> validator,
            IRequestClient<GetGradeRequest> requestClient)
        {
            _validator = validator;
            _requestClient = requestClient;
        }

        public async Task<BrokerResponse<GradeModel>> ExecuteAsync(GetGradeRequest request)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new BrokerResponse<GradeModel>
                {
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            var response = await _requestClient.GetResponse<BrokerResponse<GradeModel>>(request);

            return response.Message;
        }
    }
}
