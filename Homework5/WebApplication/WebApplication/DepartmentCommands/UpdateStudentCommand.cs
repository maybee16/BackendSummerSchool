using ClientService.DepartmentCommands.Interfaces;
using ClientService.DepartmentRequests;
using ClientService.DepartmentResponses;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;

namespace ClientService.DepartmentCommands
{
    public class UpdateDepartmentCommand : IUpdateDepartmentCommand
    {
        private readonly IValidator<UpdateDepartmentRequest> _validator;

        public UpdateDepartmentCommand(
            IValidator<UpdateDepartmentRequest> validator)
        {
            _validator = validator;
        }

        public UpdateDepartmentResponse Execute(UpdateDepartmentRequest request)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new UpdateDepartmentResponse
                {
                    Id = null,
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            return new UpdateDepartmentResponse
            {

            };
        }
    }
}
