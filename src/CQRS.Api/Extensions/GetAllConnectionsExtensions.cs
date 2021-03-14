using CQRS.Api.ResponseModel.GetConnections;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Api.Extensions
{
    public static class GetAllConnectionsExtensions
    {
        public static IActionResult ToHttpResponse(this GetAllConnectionsResponseModel response)
        {
            if (response == null || response.list == null)
            {
                return new UnauthorizedResult();
            }
            return new OkObjectResult(response.list);
        }
    }
}
