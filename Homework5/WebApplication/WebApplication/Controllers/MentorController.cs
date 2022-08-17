using ClientService.MentorCommands.Interfaces;
using ClientService.MentorRequests;
using ClientService.MentorResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ClientService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MentorController : ControllerBase
    {
        [HttpPost("create")]
        public CreateMentorResponse Create(
            [FromServices] ICreateMentorCommand command,
            [FromBody] CreateMentorRequest request)
        {
            return command.Execute(request);
        }

        [HttpGet("get")]
        public GetMentorResponse Get(
            [FromServices] IGetMentorCommand command,
            [FromQuery] Guid id)
        {
            GetMentorRequest request = new();
            request.Id = id;
            return command.Execute(request);
        }

        [HttpPost("update")]
        public UpdateMentorResponse Update(
            [FromServices] IUpdateMentorCommand command,
            [FromBody] UpdateMentorRequest request)
        {
            return command.Execute(request);
        }

        [HttpGet("find")]
        public FindMentorResponse Find(
            [FromServices] IFindMentorCommand command,
            [FromQuery] string department)
        {
            FindMentorRequest request = new();
            request.Department = department;
            return command.Execute(request);
        }
    }
}
