using EF.Data.Interfaces;
using EF.DbModels;
using MassTransit;
using MentorRequests;
using SchoolModels;
using ServerService.Mappers.Interfaces;
using StudentResponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerService.MentorConsumers
{
    public class GetMentorConsumer : IConsumer<GetMentorRequest>
    {
        private readonly IMentorsRepository _repository;
        private readonly IMentorMapper _mentorMapper;

        public GetMentorConsumer(
            IMentorsRepository repository,
            IMentorMapper mentorMapper)
        {
            _repository = repository;
            _mentorMapper = mentorMapper;
        }

        public async Task Consume(ConsumeContext<GetMentorRequest> context)
        {
            //StudentModel student = StudentMapper.ToStudent(_repository.GetStudent(context.Message.Id));
            DbMentors mentor = await _repository.GetMentorAsync(context.Message.Id);

            if (mentor is null)
            {
                await context.RespondAsync<BrokerResponse<MentorModel>>(
                new()
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Student not found" }
                });
            }
            else
            {
                await context.RespondAsync<BrokerResponse<MentorModel>>(
                  new()
                  {
                      Body = _mentorMapper.ToMentor(mentor),
                      IsSuccess = true,
                      Errors = default
                  });
            }
        }
    }
}
