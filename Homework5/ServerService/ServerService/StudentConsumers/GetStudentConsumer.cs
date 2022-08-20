using EF.Data.Interfaces;
using EF.DbModels;
using MassTransit;
using SchoolModels;
using ServerService.Mappers;
using ServerService.Mappers.Interfaces;
using StudentRequests;
using StudentResponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerService.StudentConsumers
{
    public class GetStudentConsumer : IConsumer<GetStudentRequest>
    {
        private readonly IStudentsRepository _repository;
        private readonly IStudentMapper _studentMapper;

        public GetStudentConsumer(
            IStudentsRepository repository,
            IStudentMapper studentMapper)
        {
            _repository = repository;
            _studentMapper = studentMapper;
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
                      Body = _studentMapper.ToStudent(student),
                      IsSuccess = true,
                      Errors = default
                  });
            }
        }
    }
}
