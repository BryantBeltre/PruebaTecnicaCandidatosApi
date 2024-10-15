using ApiRestFullPruebaTecnica.Application.DTOs.Metrics;
using ApiRestFullPruebaTecnica.Application.Interfaces;
using ApiRestFullPruebaTecnica.Application.Queries.Metrics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Application.Handlers.Queries.Metrics
{
    public class GetMetricsSummaryQueryHandler : IRequestHandler<GetMetricsSummaryQuery, IEnumerable<MetricSummaryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMetricsSummaryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<MetricSummaryDto>> Handle(GetMetricsSummaryQuery request, CancellationToken cancellationToken)
        {
            var summary = await _unitOfWork.ApiMetrics.GetMetricSummaryAsync(request.Date);
            return summary;
        }
    }
}
