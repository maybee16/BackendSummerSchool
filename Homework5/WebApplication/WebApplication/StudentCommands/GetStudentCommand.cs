using ClientService.StudentCommands.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MassTransit;
using SchoolModels;
using StudentRequests;
using StudentResponses;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.StudentCommands
{
    public class GetStudentCommand : IGetStudentCommand
    {
        private readonly IValidator<GetStudentRequest> _validator;
        private readonly IRequestClient<GetStudentRequest> _requestClient;

        public GetStudentCommand(
            IValidator<GetStudentRequest> validator,
            IRequestClient<GetStudentRequest> requestClient)
        {
            _validator = validator;
            _requestClient = requestClient;
        }

        public async Task<BrokerResponse<StudentModel>> ExecuteAsync(GetStudentRequest request)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new BrokerResponse<StudentModel>
                {
                    Body = null,
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            var response = await _requestClient.GetResponse<BrokerResponse<StudentModel>>(request);

            return response.Message;
        }
    }
}
