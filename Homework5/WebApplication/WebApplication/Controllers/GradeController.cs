using ClientService.GradeCommands.Interfaces;
using GradeRequests;
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
    public class GradeController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<BrokerResponse<Guid?>> CreateAsync(
            [FromServices] ICreateGradeCommand command,
            [FromBody] CreateGradeRequest request)
        {
            BrokerResponse<Guid?> response = await command.ExecuteAsync(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.Created : (int)HttpStatusCode.BadRequest;

            return response;
        }

        [HttpGet("get")]
        public async Task<BrokerResponse<GradeModel>> GetAsync(
            [FromServices] IGetGradeCommand command,
            [FromQuery] Guid id)
        {
            GetGradeRequest request = new();
            
            request.Id = id;

            BrokerResponse<GradeModel> response = await command.ExecuteAsync(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest;

            return response;
        }

        [HttpPost("update")]
        public async Task<BrokerResponse<Guid?>> UpdateAsync(
            [FromServices] IUpdateGradeCommand command,
            [FromBody] UpdateGradeRequest request)
        {
            BrokerResponse<Guid?> response = await command.ExecuteAsync(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.Created : (int)HttpStatusCode.BadRequest;

            return response;
        }

        [HttpGet("find")]
        public async Task<BrokerResponse<List<GradeModel>>> FindAsync(
            [FromServices] IFindGradeCommand command,
            [FromQuery] int value,
            [FromQuery] int? skip,
            [FromQuery] int? take)
        {
            FindGradeRequest request = new();
            
            request.Value = value;
            request.SkipCount = skip;
            request.TakeCount = take;

            BrokerResponse<List<GradeModel>> response = await command.ExecuteAsync(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest;

            return response;
        }
    }
}
