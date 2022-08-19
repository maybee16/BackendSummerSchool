using ClientService.MentorCommands.Interfaces;
using MentorRequests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolModels;
using StudentResponses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ClientService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MentorController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<BrokerResponse<Guid?>> CreateAsync(
            [FromServices] ICreateMentorCommand command,
            [FromBody] CreateMentorRequest request)
        {
            BrokerResponse<Guid?> response = new();

            response = await command.ExecuteAsync(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.Created : (int)HttpStatusCode.BadRequest;

            return response;
        }

        [HttpGet("get")]
        public async Task<BrokerResponse<MentorModel>> GetAsync(
            [FromServices] IGetMentorCommand command,
            [FromQuery] Guid id)
        {
            GetMentorRequest request = new();
            BrokerResponse<MentorModel> response = new();

            request.Id = id;

            response = await command.ExecuteAsync(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest;

            return response;
        }

        [HttpPost("update")]
        public async Task<BrokerResponse<Guid?>> UpdateAsync(
            [FromServices] IUpdateMentorCommand command,
            [FromBody] UpdateMentorRequest request)
        {
            BrokerResponse<Guid?> response = new();

            response = await command.ExecuteAsync(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.Created : (int)HttpStatusCode.BadRequest;

            return response;
        }

        [HttpGet("find")]
        public async Task<BrokerResponse<List<MentorModel>>> FindAsync(
            [FromServices] IFindMentorCommand command,
            [FromQuery] string firstName,
            [FromQuery] string lastName,
            [FromQuery] string patronymic,
            [FromQuery] string department,
            [FromQuery] int? skip,
            [FromQuery] int? take)
        {
            FindMentorRequest request = new();
            BrokerResponse<List<MentorModel>> response = new();

            request.FirstNameContains = firstName;
            request.LastNameContains = lastName;
            request.PatronymicNameContains = patronymic;
            request.Department = department;
            request.SkipCount = skip;
            request.TakeCount = take;

            response = await command.ExecuteAsync(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest;

            return response;
        }
    }
}
