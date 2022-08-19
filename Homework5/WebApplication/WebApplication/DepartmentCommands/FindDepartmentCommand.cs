using ClientService.DepartmentCommands.Interfaces;
using ClientService.DepartmentRequests;
using FluentValidation;
using FluentValidation.Results;
using GradeRequests;
using MassTransit;
using SchoolModels;
using StudentResponses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.DepartmentCommands
{
    public class FindDepartmentCommand : IFindDepartmentCommand
    {
        private readonly IValidator<FindDepartmentRequest> _validator;
        private readonly IRequestClient<FindDepartmentRequest> _requestClient;

        public FindDepartmentCommand(
            IValidator<FindDepartmentRequest> validator,
            IRequestClient<FindDepartmentRequest> requestClient)
        {
            _validator = validator;
            _requestClient = requestClient;
        }

        public async Task<BrokerResponse<List<DepartmentModel>>> ExecuteAsync(FindDepartmentRequest request)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new BrokerResponse<List<DepartmentModel>>
                {
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            var response = await _requestClient.GetResponse<BrokerResponse<List<DepartmentModel>>>(request);

            return response.Message;
        }
    }
}
