using CQRS.Api.Extensions;
using CQRS.Api.RequestModel.GetConnections;
using CQRS.Api.RequestModel.Newconnection;
using CQRS.Api.RequestModel.UpdateConnection;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace CQRS.Api.Services
{
    public class ConnectionService : ControllerBase
    {

        private readonly IMediator _mediator;

        public ConnectionService(IMediator mediator)
        {
            _mediator = mediator;            
        }

        [HttpGet(template: "GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return await HandleExceptionAsync(async () =>
            {
                //return  HandleExceptionAsync(async () => { }, Request);
                var authTokenToValidate = Request.GetAuthorizationHeader();
                GetAllConnectionsRequestModel requestModel = new GetAllConnectionsRequestModel()
                { AuthToken = authTokenToValidate,
            };
            var response =await _mediator.Send(requestModel);
            return response.ToHttpResponse();
            }, Request);

        }
        [HttpGet(template: "GetConnectionById")]
        public IActionResult GetConnectionById(string id)
        {
            var requestModel = new GetConnectionByIdRequestModel()
            {
                Id=id
            };
            var response = _mediator.Send(requestModel);
            return Ok(response);
        }

        [HttpPost(template: "CreateConnection")]
        public IActionResult CreateConnection(CreateConnectionRequestModel obj)
        {
            var requestModel = new CreateConnectionRequestModel()
            {
               
            };
            var response = _mediator.Send(requestModel);
            return Ok(response);
        }

        [HttpPut(template: "UpdateConnection")]
        public IActionResult UpdateConnection(UpdateConnectionRequestModel obj)
        {
            var requestModel = obj;
            
            var response = _mediator.Send(requestModel);
            return Ok(response);
        }

        #region helper method

        private async Task<IActionResult> HandleExceptionAsync(Func<Task<IActionResult>> asyncFunc, HttpRequest req)
        {
            try
            {
                return await asyncFunc();
            }
            catch (ValidationException validationException)
            {
                return validationException.ToHttpResponse();
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, $"An unexpected error occurred while processing {req.Path} request.");
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        #endregion
    }
}
