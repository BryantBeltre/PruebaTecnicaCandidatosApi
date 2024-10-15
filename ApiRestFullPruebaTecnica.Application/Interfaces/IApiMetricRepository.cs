using ApiRestFullPruebaTecnica.Application.DTOs.Metrics;
using ApiRestFullPruebaTecnica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Application.Interfaces
{
    public interface IApiMetricRepository
    {
        Task AddMetricAsync(ApiMetric metric);
        Task<IEnumerable<ApiMetric>> GetMetricsAsync(DateTime? Date = null);
        Task<IEnumerable<MetricSummaryDto>> GetMetricSummaryAsync(DateTime? Date = null);
    }
}
