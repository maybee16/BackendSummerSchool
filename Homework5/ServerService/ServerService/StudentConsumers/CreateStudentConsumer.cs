using EF.Data.Interfaces;
using MassTransit;
using ServerService.Mappers;
using StudentRequests;
using StudentResponses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerService.StudentConsumers
{
    public class CreateStudentConsumer : IConsumer<CreateStudentRequest>
    {
        private readonly IStudentsRepository _repository;

        public CreateStudentConsumer(IStudentsRepository repository)
        {
            _repository = repository;
         }

        public async Task Consume(ConsumeContext<CreateStudentRequest> context)
        {
            Guid? id = await _repository.AddAsync(StudentMapper.ToDbStudent(context.Message));

            if (id is null)
            {
                await context.RespondAsync<BrokerResponse<Guid?>>(
                new()
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Student not created" }
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
