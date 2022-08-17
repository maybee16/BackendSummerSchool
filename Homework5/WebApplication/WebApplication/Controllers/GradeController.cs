using ClientService.GradeCommands.Interfaces;
using ClientService.GradeRequests;
using ClientService.GradeResponses;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ClientService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GradeController : ControllerBase
    {
        [HttpPost("create")]
        public CreateGradeResponse Create(
            [FromServices] ICreateGradeCommand command,
            [FromBody] CreateGradeRequest request)
        {
            return command.Execute(request);
        }

        [HttpGet("get")]
        public GetGradeResponse Get(
            [FromServices] IGetGradeCommand command,
            [FromQuery] Guid id)
        {
            GetGradeRequest request = new();
            request.Id = id;
            return command.Execute(request);
        }

        [HttpPost("update")]
        public UpdateGradeResponse Update(
            [FromServices] IUpdateGradeCommand command,
            [FromBody] UpdateGradeRequest request)
        {
            return command.Execute(request);
        }

        [HttpGet("find")]
        public FindGradeResponse Find(
            [FromServices] IFindGradeCommand command,
            [FromQuery] int value)
        {
            FindGradeRequest request = new();
            request.Value = value;
            return command.Execute(request);
        }
    }
}
