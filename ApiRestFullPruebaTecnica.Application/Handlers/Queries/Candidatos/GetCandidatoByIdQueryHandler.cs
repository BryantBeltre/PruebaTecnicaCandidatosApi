using ApiRestFullPruebaTecnica.Application.DTOs.Candidatos;
using ApiRestFullPruebaTecnica.Application.Interfaces;
using ApiRestFullPruebaTecnica.Application.Queries.Candidatos;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Application.Handlers.Queries.Candidatos
{
    public class GetCandidatoByIdQueryHandler : IRequestHandler<GetCandidatoByIdQuery, CandidatoDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCandidatoByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CandidatoDto> Handle(GetCandidatoByIdQuery request, CancellationToken cancellationToken)
        {
            var candidato = await _unitOfWork.Candidatos.GetByIdAsync(request.Id);
            if (candidato == null)
                return null;

            return candidato == null ? null : _mapper.Map<CandidatoDto>(candidato);
        }
    }
}
