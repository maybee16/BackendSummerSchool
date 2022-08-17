using ClientService.DepartmentCommands.Interfaces;
using ClientService.DepartmentRequests;
using ClientService.DepartmentResponses;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;

namespace ClientService.DepartmentCommands
{
    public class FindDepartmentCommand : IFindDepartmentCommand
    {
        private readonly IValidator<FindDepartmentRequest> _validator;

        public FindDepartmentCommand(
            IValidator<FindDepartmentRequest> validator)
        {
            _validator = validator;
        }

        public FindDepartmentResponse Execute(FindDepartmentRequest request)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new FindDepartmentResponse
                {
                    Departments = null,
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            return new FindDepartmentResponse
            {
                Departments = null,
                IsSuccess = true,
                Errors = default
            };
        }
    }
}
