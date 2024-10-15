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
    public class GetAllCandidatosQueryHandler : IRequestHandler<GetAllCandidatosQuery, IEnumerable<CandidatoDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCandidatosQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;            
        }

        public async Task<IEnumerable<CandidatoDto>> Handle(GetAllCandidatosQuery reques, CancellationToken cancellationToken)
        {
            var candidatos = await _unitOfWork.Candidatos.GetAllAsync();
            return _mapper.Map<IEnumerable<CandidatoDto>>(candidatos);
        
        }
    }
}
