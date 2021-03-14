using CQRS.Api.RequestModel.AdminSignIn;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace CQRS.Api.Services
{
    [ApiController]
    [Route("[controller]")]
    public class AdminSignAuth : ControllerBase
    {

        private readonly IMediator _mediator;
       



        public AdminSignAuth(IMediator mediator)
        {
            _mediator = mediator;
           
        }
        [HttpPost(template: "Authenticate")]
        public IActionResult MakeOrder(AdminLogin requestModel)
        {
            var response = _mediator.Send(requestModel);
            return Ok(response);

        }

    }
}
