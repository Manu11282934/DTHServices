using CQRS.Api.Models;
using CQRS.Api.Security.AuthToken.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.Api.Security.AuthToken
{
    public class UserAuthTokenBuilder : IUserAuthTokenBuilder
    {
        private readonly IJwtTokenHandler _jwtTokenHandler;

        public UserAuthTokenBuilder(IJwtTokenHandler jwtTokenHandler)
        {
            _jwtTokenHandler = jwtTokenHandler;
          
        }

        public string IssueToken(ApplicationUser applicationUser)
        {
            var claims = GetClaims(applicationUser);
            var clientConfiguration = "userId";//_clientConfigurationProvider.GetClientConfiguration(applicationUser.ClientId);
            var secureTokenConfiguration = "";//clientConfiguration.SecureTokenConfiguration;
            if (secureTokenConfiguration == null) { throw new ArgumentNullException(nameof(secureTokenConfiguration)); }
            return _jwtTokenHandler.Create("secureTokenConfiguration.PrivateKey", claims, "secureTokenConfiguration.TokenIssuer", TimeSpan.FromSeconds(6000));
        }

        protected virtual IDictionary<string, object> GetClaims(ApplicationUser applicationUser)
        {
            var claims = new Dictionary<string, object>
            {
                //{ JwtTokenPayload.AccessCode, applicationUser.AccessCode },
                { JwtTokenPayload.FirstName, applicationUser.FirstName },
                { JwtTokenPayload.LastName, applicationUser.LastName },
                { JwtTokenPayload.Email, applicationUser.Email },
            };

            if (applicationUser.Meta != null && applicationUser.Meta.Any())
            {
                claims[JwtTokenPayload.Meta] = applicationUser.Meta;
            }

            return claims;
        }
    }
}
