using ClientService.Requests;
using ClientService.Responses;
using ClientService.StudentCommands.Interfaces;
using ClientService.StudentRequests;
using ClientService.StudentResponses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

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
            CreateStudentResponse response = new();

            response = command.Execute(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.Created : (int)HttpStatusCode.BadRequest;

            return response;
        }

        [HttpGet("get")]
        public GetStudentResponse Get(
            [FromServices] IGetStudentCommand command,
            [FromQuery] Guid id)
        {
            GetStudentResponse response = new();
            GetStudentRequest request = new();

            request.Id = id;
            
            response = command.Execute(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest;

            return response;
        }

        [HttpPost("update")]
        public UpdateStudentResponse Update(
            [FromServices] IUpdateStudentCommand command,
            [FromBody] UpdateStudentRequest request)
        {
            UpdateStudentResponse response = new();

            response = command.Execute(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.Created : (int)HttpStatusCode.BadRequest;

            return response;
        }

        [HttpGet("find")]
        public FindStudentResponse Find(
            [FromServices] IFindStudentCommand command,
            [FromQuery] string department)
        {
            FindStudentRequest request = new();
            FindStudentResponse response = new();

            request.Department = department;

            response = command.Execute(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest;

            return response;
        }
    }
}
