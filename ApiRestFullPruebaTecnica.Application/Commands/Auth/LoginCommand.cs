using ApiRestFullPruebaTecnica.Application.DTOs.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Application.Commands.Auth
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public LoginRequest LoginRequest { get; set; }
    }
}
