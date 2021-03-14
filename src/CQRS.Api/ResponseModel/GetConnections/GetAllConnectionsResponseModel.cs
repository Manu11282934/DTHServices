using CQRS.Api.Repositories.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Api.ResponseModel.GetConnections
{
    public class GetAllConnectionsResponseModel
    {
        public ICollection<ConnectionEntity> list { get; set; }
    }
}
