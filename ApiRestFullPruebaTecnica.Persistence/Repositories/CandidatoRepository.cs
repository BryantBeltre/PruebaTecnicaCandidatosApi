using ApiRestFullPruebaTecnica.Application.Interfaces;
using ApiRestFullPruebaTecnica.Domain.Entities;
using ApiRestFullPruebaTecnica.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Infrastructure.Repositories
{
    public class CandidatoRepository : ICandidatoRepository
    {
        private readonly ApplicationDbContext _context;

        public CandidatoRepository(ApplicationDbContext context)
        {
            _context = context;                
        }
        public async Task<Candidato> AddAsync(Candidato candidato)
        {
            _context.Candidatos.Add(candidato);
            return candidato;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var candidato = await _context.Candidatos.FindAsync(id);
            if (candidato == null) 
                return false;

            _context.Candidatos.Remove(candidato);
            return true;
           
        }

        public async Task<IEnumerable<Candidato>> GetAllAsync()
        {
            return await _context.Candidatos.ToListAsync();
        }

        public async Task<Candidato> GetByIdAsync(Guid id)
        {
            return await _context.Candidatos.FindAsync(id);         
        }

        public async Task<Candidato> UpdateAsync(Candidato candidato)
        {
            _context.Candidatos.Update(candidato);
            return candidato;
        }
    }
}
