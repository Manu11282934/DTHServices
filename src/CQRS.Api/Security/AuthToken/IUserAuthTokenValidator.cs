namespace CQRS.Api.Security.AuthToken
{
    public interface IUserAuthTokenValidator
    {
        AccessTokenValidationResult ValidateToken(string secret, string jwtToken, string tokenIssuer);
    }
}
