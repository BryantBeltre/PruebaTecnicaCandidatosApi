using ApiRestFullPruebaTecnica.Application.Commands.Candidatos;
using ApiRestFullPruebaTecnica.Application.DTOs.Candidatos;
using ApiRestFullPruebaTecnica.Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Application.Handlers.Commands.Candidatos
{
    public class UpdatedCandidatoCommandHandler : IRequestHandler<UpdateCandidatoCommand, CandidatoDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public UpdatedCandidatoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CandidatoDto> Handle(UpdateCandidatoCommand request, CancellationToken cancellationToken)
        {
            var candidato = await _unitOfWork.Candidatos.GetByIdAsync(request.UpdateCandidatosDto.Id);

            if (candidato == null)
                return null;

            _mapper.Map(request.UpdateCandidatosDto, candidato);
            await _unitOfWork.Candidatos.UpdateAsync(candidato);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<CandidatoDto>(candidato);           

        }
    }
}
