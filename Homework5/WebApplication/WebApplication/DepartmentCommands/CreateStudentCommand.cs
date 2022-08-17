using ClientService.DepartmentCommands.Interfaces;
using ClientService.DepartmentRequests;
using ClientService.DepartmentResponses;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;

namespace ClientService.DepartmentCommands
{
    public class CreateDepartmentCommand : ICreateDepartmentCommand
    {
        private readonly IValidator<CreateDepartmentRequest> _validator;

        public CreateDepartmentCommand(
            IValidator<CreateDepartmentRequest> validator)
        {
            _validator = validator;
        }

        public CreateDepartmentResponse Execute(CreateDepartmentRequest request)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new CreateDepartmentResponse
                {
                    Id = null,
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }


            return new CreateDepartmentResponse
            {
                Id = null,
                IsSuccess = true,
                Errors = null
            };
        }
    }
}
