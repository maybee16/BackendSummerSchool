using ClientService.GradeCommands.Interfaces;
using ClientService.GradeRequests;
using ClientService.GradeResponses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

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
            CreateGradeResponse response = new();

            response = command.Execute(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.Created : (int)HttpStatusCode.BadRequest;

            return response;
        }

        [HttpGet("get")]
        public GetGradeResponse Get(
            [FromServices] IGetGradeCommand command,
            [FromQuery] Guid id)
        {
            GetGradeRequest request = new();
            GetGradeResponse response = new();

            request.Id = id;

            response = command.Execute(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest;

            return response;
        }

        [HttpPost("update")]
        public UpdateGradeResponse Update(
            [FromServices] IUpdateGradeCommand command,
            [FromBody] UpdateGradeRequest request)
        {
            UpdateGradeResponse response = new();

            response = command.Execute(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.Created : (int)HttpStatusCode.BadRequest;

            return response;
        }

        [HttpGet("find")]
        public FindGradeResponse Find(
            [FromServices] IFindGradeCommand command,
            [FromQuery] int value)
        {
            FindGradeRequest request = new();
            FindGradeResponse response = new();

            request.Value = value;

            response = command.Execute(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest;

            return response;
        }
    }
}
