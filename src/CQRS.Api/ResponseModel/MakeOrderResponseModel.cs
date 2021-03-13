using System;

namespace CQRS.Api.ResponseModel
{
    public class MakeOrderResponseModel
    {
        public bool IsSuccess { get; set; }
        public Guid OrderId { get; set; }
    }
}
