using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Domain.Entities
{
    public class ApiMetric
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string MethodHttp { get; set; }

        public string Endpoint{ get; set;}

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public  long ResponseTimeMS { get; set; }

        public string Result { get; set; }

    }
}
