using CQRS.Api.Security.AuthToken.Jwt;
using JWT.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CQRS.Api.Security.AuthToken
{
    public class UserAuthTokenValidator : IUserAuthTokenValidator
    {
        const string TokenIssuerHeaderName = "iss";

        private readonly ILogger _logger;
        private readonly IJwtTokenHandler _jwtTokenHandler;

        public UserAuthTokenValidator(IJwtTokenHandler jwtTokenHandler, ILogger<UserAuthTokenValidator> logger)
        {
            _jwtTokenHandler = jwtTokenHandler;
            _logger = logger;
        }

        public AccessTokenValidationResult ValidateToken(string secret, string jwtToken, string tokenIssuer)
        {
            if (string.IsNullOrWhiteSpace(secret))
            {
                throw new ArgumentNullException(nameof(secret));
            }

            if (string.IsNullOrWhiteSpace(tokenIssuer))
            {
                throw new ArgumentNullException(nameof(tokenIssuer));
            }

            AccessTokenValidationResult result;
            try
            {
                var claims = _jwtTokenHandler.Parse(secret, jwtToken);
                result = ValidateTokenIssuer(claims, tokenIssuer)
                    ? new AccessTokenValidationResult(AccessTokenStatus.Valid, claims: claims)
                    : new AccessTokenValidationResult(AccessTokenStatus.Invalid, message: AccessTokenValidationResult.InvalidTokenIssuerMessage);
            }
            catch (TokenExpiredException tokenExpiredException)
            {
                _logger.LogError(tokenExpiredException, $"{AccessTokenValidationResult.TokenExpiredMessage}. jwtToken={jwtToken}");
                result = new AccessTokenValidationResult(AccessTokenStatus.Expired, message: AccessTokenValidationResult.TokenExpiredMessage);
            }
            catch (SignatureVerificationException signatureVerificationException)
            {
                _logger.LogError(signatureVerificationException, $"{AccessTokenValidationResult.InvalidSignatureMessage}. jwtToken={jwtToken}");
                result = new AccessTokenValidationResult(AccessTokenStatus.Invalid, message: AccessTokenValidationResult.InvalidSignatureMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{AccessTokenValidationResult.InvalidTokenMessage}. jwtToken={jwtToken}");
                result = new AccessTokenValidationResult(AccessTokenStatus.Invalid, message: AccessTokenValidationResult.InvalidTokenMessage);
            }
            return result;
        }

        private bool ValidateTokenIssuer(IDictionary<string, object> claims, string tokenIssuer)
        {
            if (claims != null && claims.ContainsKey(TokenIssuerHeaderName))
            {
                var tokenIssuerValue = claims[TokenIssuerHeaderName].ToString();
                return tokenIssuerValue == tokenIssuer;
            }
            return false;
        }
    }
}
