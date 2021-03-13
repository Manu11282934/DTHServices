using CQRS.Api.ResponseModel;
using MediatR;
using System;

namespace CQRS.Api.RequestModel
{
    public class GetOrderByIdRequestModel:IRequest<GetOrderByIdResponseModel>
    {
        public Guid OrderId { get; set; }
    }
}
