using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;

namespace CQRS.Api.Extensions
{
    public static class ValidationExceptionExtensions
    {
        const string Message = "Validation failed.";

        public static IActionResult ToHttpResponse(this ValidationException validationException) 
        {
            //var badRequestErrorResponse = new ErrorResponse
            //{
            //    Message = Message,
            //    StatusCode = (int)HttpStatusCode.BadRequest
            //};

            //badRequestErrorResponse.ValidationErrors = validationException.Errors.Select(error => new ValidationError
            //{
            //    PropertyName = error.PropertyName,
            //    ErrorMessage = error.ErrorMessage
            //}).ToList();

            //return new BadRequestObjectResult(badRequestErrorResponse);
            return null;
        }
    }
}
