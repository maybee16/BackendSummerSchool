using ClientService.Requests;
using ClientService.Responses;
using ClientService.StudentCommands.Interfaces;
using ClientService.StudentRequests;
using ClientService.StudentResponses;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ClientService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpPost("create")]
        public CreateStudentResponse Create(
            [FromServices] ICreateStudentCommand command,
            [FromBody] CreateStudentRequest request)
        {
            return command.Execute(request);
        }

        [HttpGet("get")]
        public GetStudentResponse Get(
            [FromServices] IGetStudentCommand command,
            [FromQuery] Guid id)
        {
            GetStudentRequest request = new();
            request.Id = id;
            return command.Execute(request);
        }

        [HttpPost("update")]
        public UpdateStudentResponse Update(
            [FromServices] IUpdateStudentCommand command,
            [FromBody] UpdateStudentRequest request)
        {
            return command.Execute(request);
        }

        [HttpGet("find")]
        public FindStudentResponse Find(
            [FromServices] IFindStudentCommand command,
            [FromQuery] string department)
        {
            FindStudentRequest request = new();
            request.Department = department;
            return command.Execute(request);
        }
    }
}
