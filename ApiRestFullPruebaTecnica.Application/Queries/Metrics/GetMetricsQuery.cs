using ApiRestFullPruebaTecnica.Application.DTOs.Metrics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Application.Queries.Metrics
{
    public class GetMetricsQuery : IRequest<IEnumerable<ApiMetricDto>>
    {
        public DateTime? Date { get; set; }
    }
}
