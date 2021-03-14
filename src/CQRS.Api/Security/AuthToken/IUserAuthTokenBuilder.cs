

using CQRS.Api.Models;

namespace CQRS.Api.Security.AuthToken
{
    public interface IUserAuthTokenBuilder
    {
        string IssueToken(ApplicationUser applicationUser);
    }
}
