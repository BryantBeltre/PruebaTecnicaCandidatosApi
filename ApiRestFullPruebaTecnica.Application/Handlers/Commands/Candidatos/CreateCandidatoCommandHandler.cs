using ApiRestFullPruebaTecnica.Application.Commands.Candidatos;
using ApiRestFullPruebaTecnica.Application.DTOs.Candidatos;
using ApiRestFullPruebaTecnica.Application.Interfaces;
using ApiRestFullPruebaTecnica.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Application.Handlers.Commands.Candidatos
{
    public class CreateCandidatoCommandHandler : IRequestHandler<CreateCandidatoCommand, CandidatoDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCandidatoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CandidatoDto> Handle(CreateCandidatoCommand request, CancellationToken cancellationToken)
        {
            var candidato = _mapper.Map<Candidato>(request.CreateCandidatosDto);
            await _unitOfWork.Candidatos.AddAsync(candidato);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<CandidatoDto>(candidato);
        }
    }
}
