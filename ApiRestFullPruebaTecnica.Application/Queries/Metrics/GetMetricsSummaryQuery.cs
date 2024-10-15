using ApiRestFullPruebaTecnica.Application.DTOs.Metrics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Application.Queries.Metrics
{
    public class GetMetricsSummaryQuery : IRequest<IEnumerable<MetricSummaryDto>>
    {
        public DateTime? Date { get; set; }

        public GetMetricsSummaryQuery(DateTime? date = null)
        {
            Date = date;
        }
    }
}
