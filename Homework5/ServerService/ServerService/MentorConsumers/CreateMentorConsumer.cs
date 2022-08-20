using EF.Data.Interfaces;
using MassTransit;
using MentorRequests;
using ServerService.Mappers;
using ServerService.Mappers.Interfaces;
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
        private readonly IMentorMapper _mentorMapper;

        public CreateMentorConsumer(
            IMentorsRepository repository,
            IMentorMapper mentorMapper)
        {
            _repository = repository;
            _mentorMapper = mentorMapper;
         }

        public async Task Consume(ConsumeContext<CreateMentorRequest> context)
        {
            Guid? id = await _repository.AddAsync(_mentorMapper.ToDbMentor(context.Message));

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
