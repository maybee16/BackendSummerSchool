using ClientService.DepartmentRequests;
using EF.Data.Interfaces;
using MassTransit;
using SchoolModels;
using ServerService.Mappers.Interfaces;
using StudentResponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerService.DepartmentConsumers
{
    public class FindDepartmentConsumer : IConsumer<FindDepartmentRequest>
    {
        private readonly IDepartmentsRepository _repository;
        private readonly IDepartmentMapper _departmentMapper;

        public FindDepartmentConsumer(
            IDepartmentsRepository repository,
            IDepartmentMapper departmentMapper)
        {
            _repository = repository;
            _departmentMapper = departmentMapper;
        }

        public async Task Consume(ConsumeContext<FindDepartmentRequest> context)
        {
            List<DepartmentModel> departments = new();

            foreach (var dbGrade in await _repository.FindAsync(_departmentMapper.ToDepartmentsFilter(context.Message)))
            {
                departments.Add(_departmentMapper.ToDepartment(dbGrade));
            }

            await context.RespondAsync<BrokerResponse<List<DepartmentModel>>>(
                new()
                {
                    Body = departments,
                    IsSuccess = true,
                    Errors = default
                });
        }
    }
}
