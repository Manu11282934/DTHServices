using System.Collections.Generic;

namespace CQRS.Api.Security.AuthToken
{
    public class AccessTokenValidationResult
    {
        public const string TokenExpiredMessage = "Token has expired.";
        public const string InvalidSignatureMessage = "Token has invalid signature.";
        public const string InvalidTokenMessage = "Invalid token.";
        public const string InvalidTokenIssuerMessage = "Invalid token issuer.";

        public AccessTokenValidationResult(AccessTokenStatus status = AccessTokenStatus.Invalid, string message = "", IDictionary<string, object> claims = null)
        {
            Status = status;
            Message = message;
            Claims = claims;
        }

        public string Message { get; private set; }
        public AccessTokenStatus Status { get; private set; }
        public IDictionary<string, object> Claims { get; private set; }
        
        public string AccessCode
        {
            get 
            {
                return Claims[JwtTokenPayload.AccessCode].ToString();
            }
        }

        public override string ToString()
        {
            return $"Status: [{Status.ToString()}] Message: [{Message}]";
        }
    }
}
