using GradeRequests;
using EF.Data.Interfaces;
using MassTransit;
using MentorRequests;
using SchoolModels;
using ServerService.Mappers;
using StudentRequests;
using StudentResponses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerService.GradeConsumers
{
    public class UpdateGradeConsumer : IConsumer<UpdateGradeRequest>
    {
        private readonly IGradesRepository _repository;

        public UpdateGradeConsumer(IGradesRepository repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<UpdateGradeRequest> context)
        {
            Guid? id = await _repository.UpdateAsync(
                        context.Message.Id,
                        context.Message.StudentId,
                        context.Message.Value);

            if (id is null)
            {
                await context.RespondAsync<BrokerResponse<Guid?>>(
                new()
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Grade not updated" }
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
