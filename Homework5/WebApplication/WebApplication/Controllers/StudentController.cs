using ClientService.StudentCommands.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SchoolModels;
using StudentRequests;
using StudentResponses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ClientService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<BrokerResponse<Guid?>> CreateAsync(
            [FromServices] ICreateStudentCommand command,
            [FromBody] CreateStudentRequest request)
        {
            BrokerResponse<Guid?> response = new();

            response = await command.ExecuteAsync(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.Created : (int)HttpStatusCode.BadRequest;

            return response;
        }

        [HttpGet("get")]
        public async Task<BrokerResponse<StudentModel>> GetAsync(
            [FromServices] IGetStudentCommand command,
            [FromQuery] Guid id)
        {
            BrokerResponse<StudentModel> response = new();
            GetStudentRequest request = new();

            request.Id = id;

            response = await command.ExecuteAsync(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest;

            return response;
        }

        [HttpPost("update")]
        public async Task<BrokerResponse<Guid?>> UpdateAsync(
            [FromServices] IUpdateStudentCommand command,
            [FromBody] UpdateStudentRequest request)
        {
            BrokerResponse<Guid?> response = new();

            response = await command.ExecuteAsync(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.Created : (int)HttpStatusCode.BadRequest;

            return response;
        }

        [HttpGet("find")]
        public async Task<BrokerResponse<List<StudentModel>>> FindAsync(
            [FromServices] IFindStudentCommand command,
            [FromQuery] string firstName,
            [FromQuery] string lastName,
            [FromQuery] string patronymic,
            [FromQuery] string department,
            [FromQuery] int? grade,
            [FromQuery] int? skip,
            [FromQuery] int? take)
        {
            FindStudentRequest request = new();
            BrokerResponse<List<StudentModel>> response = new();

            request.FirstNameContains = firstName;
            request.LastNameContains = lastName;
            request.PatronymicNameContains = patronymic;
            request.Department = department;
            request.GradeValue = grade;
            request.SkipCount = skip;
            request.TakeCount = take;

            response = await command.ExecuteAsync(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest;

            return response;
        }
    }
}
