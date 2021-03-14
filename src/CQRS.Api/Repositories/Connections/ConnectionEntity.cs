using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Api.Repositories.Connections
{
    public class ConnectionEntity
    {
        public ConnectionEntity()
        {
            id = Guid.NewGuid().ToString();
            FirstName = "ConnectionEntityFirstNameTest";
            LastName = "ConnectionEntityLastNameTest";
            OperatorName = "ConnectionEntityOperatorNameTest";
            RequestedDate = DateTime.Now.ToString();
        }
        public string id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OperatorName { get; set; }

        public string RequestedDate { get; set; }
    }
}
