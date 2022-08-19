using ClientService.DepartmentCommands.Interfaces;
using ClientService.DepartmentRequests;
using FluentValidation;
using FluentValidation.Results;
using MassTransit;
using SchoolModels;
using StudentResponses;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.DepartmentCommands
{
    public class GetDepartmentCommand : IGetDepartmentCommand
    {
        private readonly IValidator<GetDepartmentRequest> _validator;
        private readonly IRequestClient<GetDepartmentRequest> _requestClient;

        public GetDepartmentCommand(
            IValidator<GetDepartmentRequest> validator,
            IRequestClient<GetDepartmentRequest> requestClient)
        {
            _validator = validator;
            _requestClient = requestClient;
        }

        public async Task<BrokerResponse<DepartmentModel>> ExecuteAsync(GetDepartmentRequest request)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new BrokerResponse<DepartmentModel>
                {
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            var response = await _requestClient.GetResponse<BrokerResponse<DepartmentModel>>(request);

            return response.Message;
        }
    }
}
