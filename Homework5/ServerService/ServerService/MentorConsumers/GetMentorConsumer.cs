using EF.Data.Interfaces;
using EF.DbModels;
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
    public class GetMentorConsumer : IConsumer<GetMentorRequest>
    {
        private readonly IMentorsRepository _repository;

        public GetMentorConsumer(IMentorsRepository repository)
        {
            _repository = repository;
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
                      Body = MentorMapper.ToMentor(mentor),
                      IsSuccess = true,
                      Errors = default
                  });
            }
        }
    }
}
