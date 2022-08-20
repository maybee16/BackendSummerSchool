using ClientService.DepartmentRequests;
using EF.Data.Interfaces;
using MassTransit;
using StudentResponses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerService.DepartmentConsumers
{
    public class UpdateDepartmentConsumer : IConsumer<UpdateDepartmentRequest>
    {
        private readonly IDepartmentsRepository _repository;

        public UpdateDepartmentConsumer(IDepartmentsRepository repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<UpdateDepartmentRequest> context)
        {
            Guid? id = await _repository.UpdateAsync(
                        context.Message.Id,
                        context.Message.Name);

            if (id is null)
            {
                await context.RespondAsync<BrokerResponse<Guid?>>(
                new()
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Department not updated" }
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
