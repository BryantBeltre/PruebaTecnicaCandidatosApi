using ApiRestFullPruebaTecnica.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Application.Interfaces.Auth
{
    public interface IJwtTokenService
    {
        Task<LoginResponse> GetToken(string username);
    }
}
