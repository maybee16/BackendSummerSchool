using ClientService.StudentCommands.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MassTransit;
using StudentRequests;
using StudentResponses;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.StudentCommands
{
    public class UpdateStudentCommand : IUpdateStudentCommand
    {
        private readonly IValidator<UpdateStudentRequest> _validator;
        private readonly IRequestClient<UpdateStudentRequest> _requestClient;

        public UpdateStudentCommand(
            IValidator<UpdateStudentRequest> validator,
            IRequestClient<UpdateStudentRequest> requestClient)
        {
            _validator = validator;
            _requestClient = requestClient;
        }

        public async Task<BrokerResponse<Guid?>> ExecuteAsync(UpdateStudentRequest request)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new BrokerResponse<Guid?>
                {
                    //Body = null,
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            var response = await _requestClient.GetResponse<BrokerResponse<Guid?>>(request);

            return response.Message;
        }
    }
}
