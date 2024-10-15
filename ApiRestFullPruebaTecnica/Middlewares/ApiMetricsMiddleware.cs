using ApiRestFullPruebaTecnica.Application.Interfaces;
using ApiRestFullPruebaTecnica.Domain.Entities;
using System.Diagnostics;

namespace ApiRestFullPruebaTecnica.Middlewares
{
    public class ApiMetricsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ApiMetricsMiddleware> _longer;

        public ApiMetricsMiddleware(RequestDelegate next, ILogger<ApiMetricsMiddleware> longer)
        {
            _next = next;
            _longer = longer;

        }

        public async Task InvokeAsync(HttpContext context, IUnitOfWork unitOfWork)
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                await _next(context);
                stopwatch.Stop();

                var metric = new ApiMetric
                {
                    MethodHttp = context.Request.Method,
                    Endpoint = context.Request.Path,
                    Date = DateTime.UtcNow,
                    ResponseTimeMS = stopwatch.ElapsedMilliseconds,
                    Result = context.Response.StatusCode >= 200 && context.Response.StatusCode < 400 ? "OK" : "Error"
                };
                await unitOfWork.ApiMetrics.AddMetricAsync(metric);
                await unitOfWork.CommitAsync();

                _longer.LogInformation($"Métrica registrada: {metric.MethodHttp} {metric.Endpoint} {metric.Result} {metric.ResponseTimeMS}ms");
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                var metric = new ApiMetric
                {
                    MethodHttp = context.Request.Method,
                    Endpoint = context.Request.Path,
                    Date = DateTime.UtcNow,
                    ResponseTimeMS = stopwatch.ElapsedMilliseconds,
                    Result = "ERROR"
                };

                await unitOfWork.ApiMetrics.AddMetricAsync(metric);
                await unitOfWork.CommitAsync();

                _longer.LogError(ex, $"Error al procesar la solicitud: {metric.MethodHttp} {metric.Endpoint}");

                throw;
            }
        }
    }
}
