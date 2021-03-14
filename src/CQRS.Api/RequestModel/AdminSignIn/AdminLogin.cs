using CQRS.Api.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Api.RequestModel.AdminSignIn
{
    public class AdminLogin :IRequest<RegisteredUserResponse>
    {
    }
}
