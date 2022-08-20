using ClientService.DepartmentRequests;
using EF.Data.Interfaces;
using EF.DbModels;
using MassTransit;
using SchoolModels;
using ServerService.Mappers.Interfaces;
using StudentResponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerService.DepartmentConsumers
{
    public class GetDepartmentConsumer : IConsumer<GetDepartmentRequest>
    {
        private readonly IDepartmentsRepository _repository;
        private readonly IDepartmentMapper _departmentMapper;

        public GetDepartmentConsumer(
            IDepartmentsRepository repository,
            IDepartmentMapper departmentMapper)
        {
            _repository = repository;
            _departmentMapper = departmentMapper;
        }

        public async Task Consume(ConsumeContext<GetDepartmentRequest> context)
        {
            DbDepartments department = await _repository.GetDepartmentAsync(context.Message.Id);

            if (department is null)
            {
                await context.RespondAsync<BrokerResponse<DepartmentModel>>(
                new()
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Department not found" }
                });
            }
            else
            {
                await context.RespondAsync<BrokerResponse<DepartmentModel>>(
                  new()
                  {
                      Body = _departmentMapper.ToDepartment(department),
                      IsSuccess = true,
                      Errors = default
                  });
            }
        }
    }
}
