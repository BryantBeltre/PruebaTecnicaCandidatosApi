using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Application.Commands.Candidatos
{
    public class DeleteCandidatoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteCandidatoCommand(Guid id)
        {
            Id = id;
        }
    }
}
