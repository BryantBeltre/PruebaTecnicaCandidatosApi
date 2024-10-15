using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Application.Interfaces
{
    public interface IUnitOfWork
    {
        ICandidatoRepository Candidatos {  get; }
        IApiMetricRepository ApiMetrics { get; }
        Task<int> CommitAsync();
    }
}
