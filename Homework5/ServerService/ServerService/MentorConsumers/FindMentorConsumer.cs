using EF.Data.Interfaces;
using MassTransit;
using MentorRequests;
using SchoolModels;
using ServerService.Mappers.Interfaces;
using StudentResponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerService.MentorConsumers
{
    public class FindMentorConsumer : IConsumer<FindMentorRequest>
    {
        private readonly IMentorsRepository _repository;
        private readonly IMentorMapper _mentorMapper;

        public FindMentorConsumer(
            IMentorsRepository repository,
            IMentorMapper mentorMapper)
        {
            _repository = repository;
            _mentorMapper = mentorMapper;
        }

        public async Task Consume(ConsumeContext<FindMentorRequest> context)
        {
            List<MentorModel> mentors = new();

            foreach (var dbMentor in await _repository.FindAsync(_mentorMapper.ToMentorsFilter(context.Message)))
            {
                mentors.Add(_mentorMapper.ToMentor(dbMentor));
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
