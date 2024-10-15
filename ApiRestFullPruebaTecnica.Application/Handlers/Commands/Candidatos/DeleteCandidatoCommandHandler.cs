using ApiRestFullPruebaTecnica.Application.Commands.Candidatos;
using ApiRestFullPruebaTecnica.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Application.Handlers.Commands.Candidatos
{
    public class DeleteCandidatoCommandHandler : IRequestHandler<DeleteCandidatoCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCandidatoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;                    
        }

        public async Task<bool> Handle(DeleteCandidatoCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Candidatos.DeleteAsync(request.Id);

            if (result)
            {
                await _unitOfWork.CommitAsync();
            }
            return result;
        }

    }
}
