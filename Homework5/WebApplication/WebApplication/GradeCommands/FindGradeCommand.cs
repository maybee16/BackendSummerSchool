using ClientService.GradeCommands.Interfaces;
using GradeRequests;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;
using SchoolModels;
using System.Collections.Generic;
using StudentResponses;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace ClientService.GradeCommands
{
    public class FindGradeCommand : IFindGradeCommand
    {
        private readonly IValidator<FindGradeRequest> _validator;
        private readonly IRequestClient<FindGradeRequest> _requestClient;

        public FindGradeCommand(
            IValidator<FindGradeRequest> validator,
            IRequestClient<FindGradeRequest> requestClient)
        {
            _validator = validator;
            _requestClient = requestClient;
        }

        public async Task<BrokerResponse<List<GradeModel>>> ExecuteAsync(FindGradeRequest request)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new BrokerResponse<List<GradeModel>>
                {
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            var response = await _requestClient.GetResponse<BrokerResponse<List<GradeModel>>>(request);

            return response.Message;
        }
    }
}
