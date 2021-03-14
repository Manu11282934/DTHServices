using CQRS.Api.RequestModels;
using CQRS.Api.ResponseModel.NewConnectionData;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Api.RequestModel.Newconnection
{
    public class CreateConnectionRequestModel : SecureClientAwareRequest, IRequest<CreateConnectionResponseModel>
    {
        public CreateConnectionRequestModel()
        {
            id = Guid.NewGuid().ToString();
            FirstName = "NewConnectionTest";
            LastName = "LastNameTest";
            OperatorName = "OperatorNameTest";
        }
        public string id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OperatorName { get; set; }
    }
}
