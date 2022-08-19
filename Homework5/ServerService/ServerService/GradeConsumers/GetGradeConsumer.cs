using GradeRequests;
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

namespace ServerService.GradeConsumers
{
    public class GetGradeConsumer : IConsumer<GetGradeRequest>
    {
        private readonly IGradesRepository _repository;

        public GetGradeConsumer(IGradesRepository repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<GetGradeRequest> context)
        {
            //StudentModel student = StudentMapper.ToStudent(_repository.GetStudent(context.Message.Id));
            DbGrades grade = await _repository.GetGradeAsync(context.Message.Id);

            if (grade is null)
            {
                await context.RespondAsync<BrokerResponse<GradeModel>>(
                new()
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Grade not found" }
                });
            }
            else
            {
                await context.RespondAsync<BrokerResponse<GradeModel>>(
                  new()
                  {
                      Body = GradeMapper.ToGrade(grade),
                      IsSuccess = true,
                      Errors = default
                  });
            }
        }
    }
}
