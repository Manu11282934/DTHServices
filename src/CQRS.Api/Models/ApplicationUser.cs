using System.Collections.Generic;

namespace CQRS.Api.Models
{
    public class ApplicationUser
    {
        public string ClientId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string AccessCode { get; set; }

        public Dictionary<string, string> Meta { get; set; }
    }
}
