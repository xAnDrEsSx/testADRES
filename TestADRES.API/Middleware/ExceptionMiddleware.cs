using System.Net;
using System.Text.Json;
using TestADRES.API.Errors;
using TestADRES.Application.Exceptions;


namespace TestADRES.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, IHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // log
                context.Response.ContentType = "application/json";
                var statusCode = (int)HttpStatusCode.InternalServerError;
                var result = string.Empty;

                switch (ex)
                {
                    case NotFoundException notFoundException:
                        statusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case ValidationException validationException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        var validationJson = JsonSerializer.Serialize(validationException.Errors);
                        result = JsonSerializer.Serialize(new CodeErrorException(statusCode, ex.Message, validationJson));
                        break;
                    case BadRequestException badRequestException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        break;
                };

                if (string.IsNullOrEmpty(result))
                {
                    result = JsonSerializer.Serialize(new CodeErrorException(statusCode, ex.Message, ex.StackTrace));
                }

                context.Response.StatusCode = statusCode;   
                await context.Response.WriteAsync(result);
            }
        }
    }
}
