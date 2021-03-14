using System;
using System.Collections.Generic;

namespace CQRS.Api.Security.AuthToken.Jwt
{
    public interface IJwtTokenHandler
    {
        string Create(string secret, IDictionary<string, object> claims, string tokenIssuer = "", TimeSpan? tokenTimeSpan = null);
        IDictionary<string, object> Parse(string secret, string jwtToken);
    }
}
