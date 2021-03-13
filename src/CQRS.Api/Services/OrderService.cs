using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Api.Configurations;
using CQRS.Api.RequestModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CQRS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderService : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly AppSettings _appSettings;

        

        public OrderService(IMediator mediator, IOptions<AppSettings> appSettings)
        {
            _mediator = mediator;
            _appSettings = appSettings.Value;
        }
        [HttpPost(template:"makeorder")]
        public IActionResult MakeOrder([FromBody] MakeOrderRequestModel requestModel)
        {
            var response = _mediator.Send(requestModel);
            return Ok(response);

        }

        [HttpGet(template: "order")]
        public IActionResult OrderDetails([FromQuery] GetOrderByIdRequestModel requestModel)
        {
            var response = _mediator.Send(requestModel);
            return Ok(response);

        }


        [FunctionName(FunctionName.UserProfileService.GetProfile)]
        public async Task<IActionResult> GetProfile([HttpTrigger(AuthorizationLevel.Function, "get", Route = "{clientId}/Profile")] HttpRequest req, string clientId)
        {
            var userIdFromRequest = req.Query["id"];
            return await HandleExceptionAsync(async () =>
            {
                var authTokenToValidate = req.GetAuthorizationHeader();
                GetUserProfileRequest ProfileRequest = new GetUserProfileRequest
                {
                    AuthToken = authTokenToValidate,
                    ClientId = clientId,
                    UserIdFromRequest = userIdFromRequest
                };
                var response = await _mediator.Send(ProfileRequest);
                return response.ToHttpResponse();
            }, req);
        }
    }
}
