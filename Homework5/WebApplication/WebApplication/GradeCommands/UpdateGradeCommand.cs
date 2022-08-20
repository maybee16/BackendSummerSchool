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
    public class UpdateGradeCommand : IUpdateGradeCommand
    {
        private readonly IValidator<UpdateGradeRequest> _validator;
        private readonly IRequestClient<UpdateGradeRequest> _requestClient;

        public UpdateGradeCommand(
            IValidator<UpdateGradeRequest> validator,
            IRequestClient<UpdateGradeRequest> requestClient)
        {
            _validator = validator;
            _requestClient = requestClient;
        }

        public async Task<BrokerResponse<Guid?>> ExecuteAsync(UpdateGradeRequest request)
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
