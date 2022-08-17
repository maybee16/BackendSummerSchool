using ClientService.DepartmentCommands.Interfaces;
using ClientService.DepartmentRequests;
using ClientService.DepartmentResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

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
            CreateDepartmentResponse response = new();

            response = command.Execute(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.Created : (int)HttpStatusCode.BadRequest;

            return response;
        }

        [HttpGet("get")]
        public GetDepartmentResponse Get(
            [FromServices] IGetDepartmentCommand command,
            [FromQuery] Guid id)
        {
            GetDepartmentRequest request = new();
            GetDepartmentResponse response = new();

            request.Id = id;

            response = command.Execute(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest;

            return response;
        }

        [HttpPost("update")]
        public UpdateDepartmentResponse Update(
            [FromServices] IUpdateDepartmentCommand command,
            [FromBody] UpdateDepartmentRequest request)
        {
            UpdateDepartmentResponse response = new();

            response = command.Execute(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.Created : (int)HttpStatusCode.BadRequest;

            return response;
        }

        [HttpGet("find")]
        public FindDepartmentResponse Find(
            [FromServices] IFindDepartmentCommand command,
            [FromQuery] string name)
        {
            FindDepartmentRequest request = new();
            request.Name = name;
            FindDepartmentResponse response = new();

            response = command.Execute(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest;

            return response;
        }
    }
}
