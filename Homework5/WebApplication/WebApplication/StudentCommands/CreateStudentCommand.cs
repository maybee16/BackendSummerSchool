using ClientService.StudentCommands.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using StudentRequests;
using StudentResponses;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.StudentCommands
{
    public class CreateStudentCommand : ICreateStudentCommand
    {
        private readonly IValidator<CreateStudentRequest> _validator;
        private readonly IRequestClient<CreateStudentRequest> _requestClient;

        public CreateStudentCommand(
            IValidator<CreateStudentRequest> validator,
            IRequestClient<CreateStudentRequest> requestClient)
        {
            _validator = validator;
            _requestClient = requestClient;
        }

        public async Task<BrokerResponse<Guid?>> ExecuteAsync(CreateStudentRequest request)
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
