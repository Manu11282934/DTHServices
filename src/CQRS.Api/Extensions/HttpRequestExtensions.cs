using Microsoft.AspNetCore.Http;

namespace CQRS.Api.Extensions
{
    public static class HttpRequestExtensions
    {
        public static string GetAuthorizationHeader(this HttpRequest httpRequest)
        {
            const string AUTH_HEADER_NAME = "Authorization";
            const string BEARER_PREFIX = "Bearer ";

            if (httpRequest.Headers.ContainsKey(AUTH_HEADER_NAME) &&
                   httpRequest.Headers[AUTH_HEADER_NAME].ToString().StartsWith(BEARER_PREFIX))
            {
                return httpRequest.Headers[AUTH_HEADER_NAME].ToString().Substring(BEARER_PREFIX.Length);
            }
            return string.Empty;
        }

        public static T GetBody<T>(this HttpRequest httpRequest) where T : new()
        {
            return httpRequest.Body.ReadAndDeserializeFromJson<T>();
        }
    }
}
