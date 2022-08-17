using ClientService.GradeCommands.Interfaces;
using ClientService.GradeRequests;
using ClientService.GradeResponses;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;

namespace ClientService.GradeCommands
{
    public class GetGradeCommand : IGetGradeCommand
    {
        private readonly IValidator<GetGradeRequest> _validator;

        public GetGradeCommand(
            IValidator<GetGradeRequest> validator)
        {
            _validator = validator;
        }

        public GetGradeResponse Execute(GetGradeRequest request)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new GetGradeResponse
                {
                    StudentId = null,
                    Value = null,
                    Student = null,
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            return new GetGradeResponse
            {
                StudentId = null,
                Value = null,
                Student = null,
                IsSuccess = true,
                Errors = default
            };
        }
    }
}
