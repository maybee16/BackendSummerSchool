using ClientService.DepartmentRequests;
using EF.Data.Interfaces;
using GradeRequests;
using MassTransit;
using ServerService.Mappers;
using StudentResponses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerService.DepartmentConsumers
{
    public class CreateDepartmentConsumer : IConsumer<CreateDepartmentRequest>
    {
        private readonly IDepartmentsRepository _repository;

        public CreateDepartmentConsumer(IDepartmentsRepository repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<CreateDepartmentRequest> context)
        {
            Guid? id = await _repository.AddAsync(DepartmentMapper.ToDbDepartment(context.Message));

            if (id is null)
            {
                await context.RespondAsync<BrokerResponse<Guid?>>(
                new()
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Department not created" }
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
