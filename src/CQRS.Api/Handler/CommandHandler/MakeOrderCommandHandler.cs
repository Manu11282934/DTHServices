using CQRS.Api.ResponseModel;
using CQRS.Api.RequestModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Api.Handler.CommandHandler
{
    public class MakeOrderCommandHandler : IRequestHandler<MakeOrderRequestModel, MakeOrderResponseModel>
    {
        public async Task<MakeOrderResponseModel> Handle(MakeOrderRequestModel request, CancellationToken cancellationToken)
        {
            var result = new MakeOrderResponseModel()
            {
                IsSuccess = true,
                OrderId = Guid.NewGuid()
            };
            return result;
        }
    }
}
