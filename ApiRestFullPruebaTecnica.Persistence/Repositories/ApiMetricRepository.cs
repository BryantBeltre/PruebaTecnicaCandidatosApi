using ApiRestFullPruebaTecnica.Application.DTOs.Metrics;
using ApiRestFullPruebaTecnica.Application.Interfaces;
using ApiRestFullPruebaTecnica.Domain.Entities;
using ApiRestFullPruebaTecnica.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Infrastructure.Repositories
{
    public class ApiMetricRepository : IApiMetricRepository
    {
        private readonly ApplicationDbContext _context;

        public ApiMetricRepository(ApplicationDbContext context)
        {
            _context = context;            
        }

        public async Task AddMetricAsync(ApiMetric metric)
        {
            
            await _context.ApiMetrics.AddAsync(metric);
        }

        public async Task<IEnumerable<ApiMetric>> GetMetricsAsync(DateTime? date = null)
        {
            var query   = _context.ApiMetrics.AsQueryable();
            if (date.HasValue)
            {
                var startDate = date.Value.Date;
                var endDate = startDate.AddDays(1);
                query = query.Where(m => m.Date >= startDate && m.Date < endDate);
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<MetricSummaryDto>> GetMetricSummaryAsync(DateTime? date = null)
        {
            var query = _context.ApiMetrics.AsQueryable();

            if (date.HasValue)
            {
                var startDate = date.Value.Date;
                var endDate = startDate.AddDays(1);
                query = query.Where(m => m.Date >= startDate && m.Date < endDate);
            }
            var groupedMetrics = await query
                .GroupBy(m => new { m.MethodHttp, m.Endpoint, m.Result })
                .Select(g => new MetricSummaryDto
                {
                    MethodHttp = g.Key.MethodHttp,
                    Endpoint = g.Key.Endpoint,
                    Result = g.Key.Result,
                    ConsumptionQuantity = g.Count(),
                    AverageResponseTime = g.Average(m => m.ResponseTimeMS),
                    ResponseTimeMin = g.Min(m => m.ResponseTimeMS),
                    ResponseTimeMax = g.Max(m => m.ResponseTimeMS),
                    TPM = g.Count() / 60.0
                })
                .ToListAsync();

            return groupedMetrics;
        }
    }
}
