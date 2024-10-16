﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Application.DTOs.Candidatos
{
    public class CandidatoDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public string AppliedPosition { get; set; }

        public DateTime DateAppliedPosition { get; set; }
    }
}
