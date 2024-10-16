using Azure.Core.Serialization;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiRestFullPruebaTecnica.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;            
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error de Exception, no esperado");
                await HandleExceptionAsync(context, ex);
                throw;
            }
        }

        public Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                Message = "Se produjo un error interno en el servidor.",
                StatusCode = 500,
                Detailed = exception.Message
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));

        }

    }
}
