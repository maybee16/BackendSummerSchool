using ClientService.GradeCommands.Interfaces;
using ClientService.GradeRequests;
using ClientService.GradeResponses;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;

namespace ClientService.GradeCommands
{
    public class CreateGradeCommand : ICreateGradeCommand
    {
        private readonly IValidator<CreateGradeRequest> _validator;

        public CreateGradeCommand(
            IValidator<CreateGradeRequest> validator)
        {
            _validator = validator;
        }

        public CreateGradeResponse Execute(CreateGradeRequest request)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new CreateGradeResponse
                {
                    Id = null,
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            return new CreateGradeResponse
            {
                Id = null,
                IsSuccess = true,
                Errors = default
            };
        }
    }
}
