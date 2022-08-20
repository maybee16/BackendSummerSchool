using ClientService.DepartmentCommands.Interfaces;
using ClientService.DepartmentRequests;
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
    public class DepartmentController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<BrokerResponse<Guid?>> CreateAsync(
            [FromServices] ICreateDepartmentCommand command,
            [FromBody] CreateDepartmentRequest request)
        {
            BrokerResponse<Guid?> response = await command.ExecuteAsync(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.Created : (int)HttpStatusCode.BadRequest;

            return response;
        }

        [HttpGet("get")]
        public async Task<BrokerResponse<DepartmentModel>> GetAsync(
            [FromServices] IGetDepartmentCommand command,
            [FromQuery] Guid id)
        {
            GetDepartmentRequest request = new();
            
            request.Id = id;

            BrokerResponse<DepartmentModel> response = await command.ExecuteAsync(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest;

            return response;
        }

        [HttpPost("update")]
        public async Task<BrokerResponse<Guid?>> UpdateAsync(
            [FromServices] IUpdateDepartmentCommand command,
            [FromBody] UpdateDepartmentRequest request)
        {
            BrokerResponse<Guid?> response = await command.ExecuteAsync(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.Created : (int)HttpStatusCode.BadRequest;

            return response;
        }

        [HttpGet("find")]
        public async Task<BrokerResponse<List<DepartmentModel>>> FindAsync(
            [FromServices] IFindDepartmentCommand command,
            [FromQuery] string name,
            [FromQuery] int? skip,
            [FromQuery] int? take)
        {
            FindDepartmentRequest request = new();
            
            request.NameContains = name;
            request.SkipCount = skip;
            request.TakeCount = take;

            BrokerResponse<List<DepartmentModel>> response = await command.ExecuteAsync(request);
            HttpContext.Response.StatusCode = response.IsSuccess ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest;

            return response;
        }
    }
}
