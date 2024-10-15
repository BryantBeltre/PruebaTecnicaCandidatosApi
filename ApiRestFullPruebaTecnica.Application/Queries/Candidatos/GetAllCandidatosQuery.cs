using ApiRestFullPruebaTecnica.Application.DTOs.Candidatos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Application.Queries.Candidatos
{
    public class GetAllCandidatosQuery : IRequest<IEnumerable<CandidatoDto>>
    {
    }
}
