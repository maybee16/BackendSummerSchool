using EF.Data.Interfaces;
using MassTransit;
using SchoolModels;
using ServerService.Mappers.Interfaces;
using StudentRequests;
using StudentResponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerService.StudentConsumers
{
    public class FindStudentConsumer : IConsumer<FindStudentRequest>
    {
        private readonly IStudentsRepository _repository;
        private readonly IStudentMapper _studentMapper;

        public FindStudentConsumer(
            IStudentsRepository repository,
            IStudentMapper studentMapper)
        {
            _repository = repository;
            _studentMapper = studentMapper;
        }

        public async Task Consume(ConsumeContext<FindStudentRequest> context)
        {
            List<StudentModel> students = new();

            foreach (var dbStudent in await _repository.FindAsync(_studentMapper.ToStudentsFilter(context.Message)))
            {
                students.Add(_studentMapper.ToStudent(dbStudent));
            }

            await context.RespondAsync<BrokerResponse<List<StudentModel>>>(
                new()
                {
                    Body = students,
                    IsSuccess = true,
                    Errors = default
                });
        }
    }
}
