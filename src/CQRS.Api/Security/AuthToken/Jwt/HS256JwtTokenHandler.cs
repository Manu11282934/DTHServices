using JWT.Algorithms;
using JWT.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQRS.Api.Security.AuthToken.Jwt
{
    public class HS256JwtTokenHandler : IJwtTokenHandler
    {
        private readonly JwtBuilder _jwtBuilder;

        public HS256JwtTokenHandler()
        {            
            _jwtBuilder = new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm());
        }

        public string Create(string secret, IDictionary<string, object> claims, string tokenIssuer = "", TimeSpan? tokenTimeSpan = null)
        {
            if (string.IsNullOrWhiteSpace(secret))
            {
                throw new ArgumentNullException(nameof(secret));
            }

            if (claims is null || !claims.Any())
            {
                throw new ArgumentNullException(nameof(claims));
            }

            _jwtBuilder.WithSecret(Encoding.UTF8.GetBytes(secret));

            //add Issuer if specified
            if (!string.IsNullOrWhiteSpace(tokenIssuer))
            {
                _jwtBuilder.AddClaim(ClaimName.Issuer, tokenIssuer);
            }

            //add ExpirationTime if specified
            if (tokenTimeSpan.HasValue)
            {
                _jwtBuilder.AddClaim(ClaimName.ExpirationTime, DateTimeOffset.UtcNow.Add(tokenTimeSpan.Value).ToUnixTimeSeconds());
            }

            //include all provided claims
            foreach (var claim in claims)
            {
                _jwtBuilder.AddClaim(claim.Key, claim.Value);
            }

            //create and return the token
            return _jwtBuilder.Encode();
        }

        public IDictionary<string, object> Parse(string secret, string jwtToken)
        {
            if (string.IsNullOrWhiteSpace(secret))
            {
                throw new ArgumentNullException(nameof(secret));
            }

            if (string.IsNullOrWhiteSpace(jwtToken))
            {
                throw new ArgumentNullException(nameof(jwtToken));
            }

            return _jwtBuilder
                .WithSecret(Encoding.UTF8.GetBytes(secret))
                .MustVerifySignature()
                .Decode<IDictionary<string, object>>(jwtToken);
        }
    }
}
