using EF.Data.Interfaces;
using MassTransit;
using MentorRequests;
using StudentResponses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerService.MentorConsumers
{
    public class UpdateMentorConsumer : IConsumer<UpdateMentorRequest>
    {
        private readonly IMentorsRepository _repository;

        public UpdateMentorConsumer(IMentorsRepository repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<UpdateMentorRequest> context)
        {
            Guid? id = await _repository.UpdateAsync(
                        context.Message.Id,
                        context.Message.FirstName,
                        context.Message.LastName,
                        context.Message.Patronymic,
                        context.Message.Department);

            if (id is null)
            {
                await context.RespondAsync<BrokerResponse<Guid?>>(
                new()
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Mentor not updated" }
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
