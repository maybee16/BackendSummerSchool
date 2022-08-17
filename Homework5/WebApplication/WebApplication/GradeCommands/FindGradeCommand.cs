using ClientService.GradeCommands.Interfaces;
using ClientService.GradeRequests;
using ClientService.GradeResponses;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;

namespace ClientService.GradeCommands
{
    public class FindGradeCommand : IFindGradeCommand
    {
        private readonly IValidator<FindGradeRequest> _validator;

        public FindGradeCommand(
            IValidator<FindGradeRequest> validator)
        {
            _validator = validator;
        }

        public FindGradeResponse Execute(FindGradeRequest request)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new FindGradeResponse
                {
                    Grades = null,
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            return new FindGradeResponse
            {
            };
        }
    }
}
