using ClientService.StudentCommands.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SchoolModels;
using StudentRequests;
using StudentResponses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.StudentCommands
{
    public class FindStudentCommand : IFindStudentCommand
    {
        private readonly IValidator<FindStudentRequest> _validator;
        private readonly IRequestClient<FindStudentRequest> _requestClient;

        public FindStudentCommand(
            IValidator<FindStudentRequest> validator,
            [FromServices] IRequestClient<FindStudentRequest> requestClient)
        {
            _validator = validator;
            _requestClient = requestClient;
        }

        public async Task<BrokerResponse<List<StudentModel>>> ExecuteAsync(FindStudentRequest request)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new BrokerResponse<List<StudentModel>>
                {
                    Body = null,
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            var response = await _requestClient.GetResponse<BrokerResponse<List<StudentModel>>>(request);

            return response.Message;
        }
    }
}
