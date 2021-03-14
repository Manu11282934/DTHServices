using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Api.Models;

namespace CQRS.Api.Repositories.Admin
{
    public interface IAdminRepository
    {
        Task<ApplicationUser> Validate();
    }
}
