using EF.Data.Interfaces;
using GradeRequests;
using MassTransit;
using ServerService.Mappers.Interfaces;
using StudentResponses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerService.GradeConsumers
{
    public class CreateGradeConsumer : IConsumer<CreateGradeRequest>
    {
        private readonly IGradesRepository _repository;
        private readonly IGradeMapper _gradeMapper;

        public CreateGradeConsumer(
            IGradesRepository repository,
            IGradeMapper gradeMapper)
        {
            _repository = repository;
            _gradeMapper = gradeMapper;
        }

        public async Task Consume(ConsumeContext<CreateGradeRequest> context)
        {
            Guid? id = await _repository.AddAsync(_gradeMapper.ToDbGrade(context.Message));

            if (id is null)
            {
                await context.RespondAsync<BrokerResponse<Guid?>>(
                new()
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Grade not created" }
                });
            }
            else
            {
                await context.RespondAsync<BrokerResponse<Guid?>>(
                  new()
                  {
                      Body = id,
                      IsSuccess = true,
                      Errors = default
                  });
            }
        }
    }
}
