using LDI.AuthService.FunctionApp.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace CQRS.Api.Services
{
    public abstract class BaseHttpFunction<T>
    {
        private readonly ILogger<T> _logger;
        public BaseHttpFunction(ILogger<T> logger)
        {
            _logger = logger;
        }

        protected async Task<IActionResult> HandleExceptionAsync(Func<Task<IActionResult>> asyncFunc, HttpRequest req)
        {
            try
            {
                return await asyncFunc();
            }
            catch (AuthTokenValidationException) 
            {
                return new UnauthorizedResult();
            }
            catch (ValidationException validationException)
            {
                //  return validationException.ToHttpResponse();
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An unexpected error occurred while processing {req.Path} request.");
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
