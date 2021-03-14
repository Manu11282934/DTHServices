using CQRS.Api.RequestModels;
using CQRS.Api.ResponseModel.UpdateConnection;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Api.RequestModel.UpdateConnection
{
    public class UpdateConnectionRequestModel : SecureClientAwareRequest, IRequest<UpdateConnectionResponseModel>
    {

        public UpdateConnectionRequestModel()
        {
           
            FirstName = "UpdateNewConnectionTest";
            LastName = "UpdateLastNameTest";
            OperatorName = "UpdateOperatorNameTest";
        }
        public string id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OperatorName { get; set; }
    }
}
