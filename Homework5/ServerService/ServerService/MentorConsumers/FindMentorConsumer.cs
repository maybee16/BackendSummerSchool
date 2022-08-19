using EF.Data.Interfaces;
using MassTransit;
using MentorRequests;
using SchoolModels;
using ServerService.Mappers;
using StudentRequests;
using StudentResponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerService.MentorConsumers
{
    public class FindMentorConsumer : IConsumer<FindMentorRequest>
    {
        private readonly IMentorsRepository _repository;

        public FindMentorConsumer(IMentorsRepository repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<FindMentorRequest> context)
        {
            List<MentorModel> mentors = new();

            foreach (var dbMentor in await _repository.FindAsync(MentorMapper.ToMentorsFilter(context.Message)))
            {
                mentors.Add(MentorMapper.ToMentor(dbMentor));
            }

            await context.RespondAsync<BrokerResponse<List<MentorModel>>>(
                new()
                {
                    Body = mentors,
                    IsSuccess = true,
                    Errors = default
                });
        }
    }
}
