using EF.Data.Interfaces;
using MassTransit;
using ServerService.Mappers;
using ServerService.Mappers.Interfaces;
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
        private readonly IStudentMapper _studentMapper;

        public CreateStudentConsumer(
            IStudentsRepository repository,
            IStudentMapper studentMapper)
        {
            _repository = repository;
            _studentMapper = studentMapper;
         }

        public async Task Consume(ConsumeContext<CreateStudentRequest> context)
        {
            Guid? id = await _repository.AddAsync(_studentMapper.ToDbStudent(context.Message));

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
