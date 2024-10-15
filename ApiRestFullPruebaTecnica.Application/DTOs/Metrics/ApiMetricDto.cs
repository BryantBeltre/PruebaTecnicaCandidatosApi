using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Application.DTOs.Metrics
{
    public class ApiMetricDto
    {
        public Guid Id { get; set; }

        public string MethodHttp { get; set; }

        public string Endpoint { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public long ResponseTimeMS { get; set; }

        public string Result { get; set; }

    }
}
