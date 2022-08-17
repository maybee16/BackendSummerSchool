using ClientService.DepartmentCommands.Interfaces;
using ClientService.DepartmentRequests;
using ClientService.DepartmentResponses;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;

namespace ClientService.DepartmentCommands
{
    public class GetDepartmentCommand : IGetDepartmentCommand
    {
        private readonly IValidator<GetDepartmentRequest> _validator;

        public GetDepartmentCommand(
            IValidator<GetDepartmentRequest> validator)
        {
            _validator = validator;
        }

        public GetDepartmentResponse Execute(GetDepartmentRequest request)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new GetDepartmentResponse
                {
                    Name = null,
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            return new GetDepartmentResponse
            {
                Name = null,
                IsSuccess = true,
                Errors = default
            };
        }
    }
}
