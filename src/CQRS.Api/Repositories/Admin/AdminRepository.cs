using CQRS.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Api.Repositories.Admin
{
    public class AdminRepository : IAdminRepository
    {
        public async Task<ApplicationUser> Validate()
        {
            return new ApplicationUser
            {
                Email = "testmail@gmail.com",
                FirstName="testFirstName",
                LastName="testLastName",
            };
        }
    }
}
