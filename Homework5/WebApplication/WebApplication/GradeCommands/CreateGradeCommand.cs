using ClientService.GradeCommands.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using GradeRequests;
using MassTransit;
using StudentResponses;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.GradeCommands
{
    public class CreateGradeCommand : ICreateGradeCommand
    {
        private readonly IValidator<CreateGradeRequest> _validator;
        private readonly IRequestClient<CreateGradeRequest> _requestClient;

        public CreateGradeCommand(
            IValidator<CreateGradeRequest> validator,
            IRequestClient<CreateGradeRequest> requestClient)
        {
            _validator = validator;
            _requestClient = requestClient;
        }

        public async Task<BrokerResponse<Guid?>> ExecuteAsync(CreateGradeRequest request)
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
