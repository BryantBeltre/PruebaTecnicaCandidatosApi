using ApiRestFullPruebaTecnica.Application.Queries.Metrics;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestFullPruebaTecnica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MetricsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MetricsController(IMediator mediator)
        {
            _mediator = mediator;
            
        }

        //Obtener datos peticion GET: api/metrics
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetMetrics([FromQuery] DateTime? date)
        {
            var query = new GetMetricsQuery { Date = date };
            var metrics = await _mediator.Send(query);
            return Ok(metrics);
        }

        /// <summary>
        /// Obtener el resumen de métricas de consumo de las APIs.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet("summary")]
        public async Task<IActionResult> GetMetricsSummary([FromQuery] DateTime? date = null)
        {
            var query = new GetMetricsSummaryQuery(date);
            var summary = await _mediator.Send(query);
            return Ok(summary);
        }
    }
}
