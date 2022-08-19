using EF.Data.Interfaces;
using EF.DbModels;
using MassTransit;
using SchoolModels;
using ServerService.Mappers;
using StudentRequests;
using StudentResponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerService.StudentConsumers
{
    public class GetStudentConsumer : IConsumer<GetStudentRequest>
    {
        private readonly IStudentsRepository _repository;

        public GetStudentConsumer(IStudentsRepository repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<GetStudentRequest> context)
        {
            //StudentModel student = StudentMapper.ToStudent(_repository.GetStudent(context.Message.Id));
            DbStudents student = await _repository.GetStudentAsync(context.Message.Id);
            
            if (student is null)
            {
                await context.RespondAsync<BrokerResponse<StudentModel>>(
                new()
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Student not found" }
                });
            }
            else
            {
                await context.RespondAsync<BrokerResponse<StudentModel>>(
                  new()
                  {
                      Body = StudentMapper.ToStudent(student),
                      IsSuccess = true,
                      Errors = default
                  });
            }
        }
    }
}
