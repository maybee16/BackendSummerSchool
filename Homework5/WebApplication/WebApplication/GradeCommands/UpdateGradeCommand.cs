using ClientService.GradeCommands.Interfaces;
using ClientService.GradeRequests;
using ClientService.GradeResponses;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;

namespace ClientService.GradeCommands
{
    public class UpdateGradeCommand : IUpdateGradeCommand
    {
        private readonly IValidator<UpdateGradeRequest> _validator;

        public UpdateGradeCommand(
            IValidator<UpdateGradeRequest> validator)
        {
            _validator = validator;
        }

        public UpdateGradeResponse Execute(UpdateGradeRequest request)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new UpdateGradeResponse
                {
                    Id = null,
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            return new UpdateGradeResponse
            {

            };
        }
    }
}
