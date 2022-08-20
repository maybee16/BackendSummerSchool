using EF.Data.Interfaces;
using GradeRequests;
using MassTransit;
using SchoolModels;
using ServerService.Mappers.Interfaces;
using StudentResponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerService.GradeConsumers
{
    public class FindGradeConsumer : IConsumer<FindGradeRequest>
    {
        private readonly IGradesRepository _repository;
        private readonly IGradeMapper _gradeMapper;

        public FindGradeConsumer(
            IGradesRepository repository,
            IGradeMapper gradeMapper)
        {
            _repository = repository;
            _gradeMapper = gradeMapper;
        }

        public async Task Consume(ConsumeContext<FindGradeRequest> context)
        {
            List<GradeModel> grades = new();

            foreach (var dbGrade in await _repository.FindAsync(_gradeMapper.ToGradesFilter(context.Message)))
            {
                grades.Add(_gradeMapper.ToGrade(dbGrade));
            }

            await context.RespondAsync<BrokerResponse<List<GradeModel>>>(
                new()
                {
                    Body = grades,
                    IsSuccess = true,
                    Errors = default
                });
        }
    }
}
