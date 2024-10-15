using ApiRestFullPruebaTecnica.Application.Interfaces;
using ApiRestFullPruebaTecnica.Infrastructure.Persistence;
using ApiRestFullPruebaTecnica.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Infrastructure.UniOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ICandidatoRepository Candidatos { get; set; }
        public IApiMetricRepository ApiMetrics{ get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Candidatos = new CandidatoRepository(_context);
            ApiMetrics = new ApiMetricRepository(_context);
        }


        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
