using ApiRestFullPruebaTecnica.Application.DTOs.Candidatos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Application.Commands.Candidatos
{
    public class CreateCandidatoCommand : IRequest<CandidatoDto>
    {
        public CreateCandidatosDto CreateCandidatosDto { get; set; }
    }
}
