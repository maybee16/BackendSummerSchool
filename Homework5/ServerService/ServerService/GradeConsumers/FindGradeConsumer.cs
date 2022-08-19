using EF.Data.Interfaces;
using GradeRequests;
using MassTransit;
using SchoolModels;
using ServerService.Mappers;
using StudentResponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerService.GradeConsumers
{
    public class FindGradeConsumer : IConsumer<FindGradeRequest>
    {
        private readonly IGradesRepository _repository;

        public FindGradeConsumer(IGradesRepository repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<FindGradeRequest> context)
        {
            List<GradeModel> grades = new();

            foreach (var dbGrade in await _repository.FindAsync(GradeMapper.ToGradesFilter(context.Message)))
            {
                grades.Add(GradeMapper.ToGrade(dbGrade));
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
