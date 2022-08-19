using EF.Data.Interfaces;
using MassTransit;
using MentorRequests;
using ServerService.Mappers;
using StudentRequests;
using StudentResponses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerService.MentorConsumers
{
    public class CreateMentorConsumer : IConsumer<CreateMentorRequest>
    {
        private readonly IMentorsRepository _repository;

        public CreateMentorConsumer(IMentorsRepository repository)
        {
            _repository = repository;
         }

        public async Task Consume(ConsumeContext<CreateMentorRequest> context)
        {
            Guid? id = await _repository.AddAsync(MentorMapper.ToDbMentor(context.Message));

            if (id is null)
            {
                await context.RespondAsync<BrokerResponse<Guid?>>(
                new()
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Mentor not created" }
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
