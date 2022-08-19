using EF.Data.Interfaces;
using MassTransit;
using SchoolModels;
using ServerService.Mappers;
using StudentRequests;
using StudentResponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerService.StudentConsumers
{
    public class FindStudentConsumer : IConsumer<FindStudentRequest>
    {
        private readonly IStudentsRepository _repository;

        public FindStudentConsumer(IStudentsRepository repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<FindStudentRequest> context)
        {
            List<StudentModel> students = new();

            foreach (var dbStudent in await _repository.FindAsync(StudentMapper.ToStudentsFilter(context.Message)))
            {
                students.Add(StudentMapper.ToStudent(dbStudent));
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
