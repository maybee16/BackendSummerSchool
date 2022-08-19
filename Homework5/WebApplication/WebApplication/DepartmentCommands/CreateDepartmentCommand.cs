using ClientService.DepartmentCommands.Interfaces;
using ClientService.DepartmentRequests;
using FluentValidation;
using FluentValidation.Results;
using MassTransit;
using StudentResponses;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.DepartmentCommands
{
    public class CreateDepartmentCommand : ICreateDepartmentCommand
    {
        private readonly IValidator<CreateDepartmentRequest> _validator;
        private readonly IRequestClient<CreateDepartmentRequest> _requestClient;

        public CreateDepartmentCommand(
            IValidator<CreateDepartmentRequest> validator,
            IRequestClient<CreateDepartmentRequest> requestClient)
        {
            _validator = validator;
            _requestClient = requestClient;
        }

        public async Task<BrokerResponse<Guid?>> ExecuteAsync(CreateDepartmentRequest request)
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
