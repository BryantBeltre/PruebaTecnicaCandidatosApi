using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Domain.Entities
{
    public class Candidato
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime BithDate { get; set; }

        public string AppliedPosition { get; set;}

        public DateTime DateAppliedPosition { get; set; } = DateTime.UtcNow;

    }
}
