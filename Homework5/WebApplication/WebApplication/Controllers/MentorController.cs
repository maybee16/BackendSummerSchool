using ClientService.MentorCommands.Interfaces;
using ClientService.MentorRequests;
using ClientService.MentorResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

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
            CreateMentorResponse response = new();

            response = command.Execute(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.Created : (int)HttpStatusCode.BadRequest;

            return response;
        }

        [HttpGet("get")]
        public GetMentorResponse Get(
            [FromServices] IGetMentorCommand command,
            [FromQuery] Guid id)
        {
            GetMentorRequest request = new();
            GetMentorResponse response = new();

            request.Id = id;

            response = command.Execute(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest;

            return response;
        }

        [HttpPost("update")]
        public UpdateMentorResponse Update(
            [FromServices] IUpdateMentorCommand command,
            [FromBody] UpdateMentorRequest request)
        {
            UpdateMentorResponse response = new();

            response = command.Execute(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.Created : (int)HttpStatusCode.BadRequest;

            return response;
        }

        [HttpGet("find")]
        public FindMentorResponse Find(
            [FromServices] IFindMentorCommand command,
            [FromQuery] string department)
        {
            FindMentorRequest request = new();
            FindMentorResponse response = new();

            request.Department = department;

            response = command.Execute(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest;

            return response;
        }
    }
}
