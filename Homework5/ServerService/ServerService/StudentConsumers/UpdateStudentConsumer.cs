using EF.Data.Interfaces;
using MassTransit;
using StudentRequests;
using StudentResponses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerService.StudentConsumers
{
    public class UpdateStudentConsumer : IConsumer<UpdateStudentRequest>
    {
        private readonly IStudentsRepository _repository;

        public UpdateStudentConsumer(IStudentsRepository repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<UpdateStudentRequest> context)
        {
            Guid? id = await _repository.UpdateAsync(
                        context.Message.Id,
                        context.Message.FirstName,
                        context.Message.LastName,
                        context.Message.Patronymic,
                        context.Message.Department);

            if (id is null)
            {
                await context.RespondAsync<BrokerResponse<Guid?>>(
                new()
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Student not updated" }
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
