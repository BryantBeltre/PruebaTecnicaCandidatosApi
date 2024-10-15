using ApiRestFullPruebaTecnica.Application.DTOs.Metrics;
using ApiRestFullPruebaTecnica.Application.Interfaces;
using ApiRestFullPruebaTecnica.Application.Queries.Metrics;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Application.Handlers.Queries.Metrics
{
    public class GetMetricsQueryHandler : IRequestHandler<GetMetricsQuery, IEnumerable<ApiMetricDto>>    
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMetricsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<IEnumerable<ApiMetricDto>> Handle(GetMetricsQuery request, CancellationToken cancellationToken)
        {
            var metrics = await _unitOfWork.ApiMetrics.GetMetricsAsync(request.Date);
            return _mapper.Map<IEnumerable<ApiMetricDto>>(metrics);
        }

    }
}
