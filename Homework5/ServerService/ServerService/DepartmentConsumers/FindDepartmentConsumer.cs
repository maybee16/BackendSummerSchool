using ClientService.DepartmentRequests;
using EF.Data.Interfaces;
using GradeRequests;
using MassTransit;
using SchoolModels;
using ServerService.Mappers;
using StudentResponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerService.DepartmentConsumers
{
    public class FindDepartmentConsumer : IConsumer<FindDepartmentRequest>
    {
        private readonly IDepartmentsRepository _repository;

        public FindDepartmentConsumer(IDepartmentsRepository repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<FindDepartmentRequest> context)
        {
            List<DepartmentModel> departments = new();

            foreach (var dbGrade in await _repository.FindAsync(DepartmentMapper.ToDepartmentsFilter(context.Message)))
            {
                departments.Add(DepartmentMapper.ToDepartment(dbGrade));
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
