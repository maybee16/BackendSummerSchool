using EF.Data.Interfaces;
using GradeRequests;
using MassTransit;
using ServerService.Mappers;
using StudentResponses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerService.GradeConsumers
{
    public class CreateGradeConsumer : IConsumer<CreateGradeRequest>
    {
        private readonly IGradesRepository _repository;

        public CreateGradeConsumer(IGradesRepository repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<CreateGradeRequest> context)
        {
            Guid? id = await _repository.AddAsync(GradeMapper.ToDbGrade(context.Message));

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
