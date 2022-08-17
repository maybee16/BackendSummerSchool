using ClientService.DepartmentCommands.Interfaces;
using ClientService.DepartmentRequests;
using ClientService.DepartmentResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ClientService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        [HttpPost("create")]
        public CreateDepartmentResponse Create(
            [FromServices] ICreateDepartmentCommand command,
            [FromBody] CreateDepartmentRequest request)
        {
            return command.Execute(request);
        }

        [HttpGet("get")]
        public GetDepartmentResponse Get(
            [FromServices] IGetDepartmentCommand command,
            [FromQuery] Guid id)
        {
            GetDepartmentRequest request = new();
            request.Id = id;
            return command.Execute(request);
        }

        [HttpPost("update")]
        public UpdateDepartmentResponse Update(
            [FromServices] IUpdateDepartmentCommand command,
            [FromBody] UpdateDepartmentRequest request)
        {
            return command.Execute(request);
        }

        [HttpGet("find")]
        public FindDepartmentResponse Find(
            [FromServices] IFindDepartmentCommand command,
            [FromQuery] string name)
        {
            FindDepartmentRequest request = new();
            request.Name = name;
            return command.Execute(request);
        }
    }
}
