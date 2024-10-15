using ApiRestFullPruebaTecnica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Application.Interfaces
{
    public interface ICandidatoRepository
    {
        Task<IEnumerable<Candidato>> GetAllAsync();
        Task<Candidato> GetByIdAsync(Guid id);
        Task<Candidato> AddAsync(Candidato candidato);
        Task<Candidato> UpdateAsync(Candidato candidato);
        Task<bool> DeleteAsync(Guid id);
    }
}
