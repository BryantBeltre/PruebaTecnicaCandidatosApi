using ApiRestFullPruebaTecnica.Application.Commands.Auth;
using ApiRestFullPruebaTecnica.Application.DTOs.Auth;
using ApiRestFullPruebaTecnica.Application.Interfaces.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Application.Handlers.Commands.Auth
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IJwtTokenService _jwtTokenService;

        public LoginCommandHandler(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;            
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var loginRequest = request.LoginRequest;

            if (loginRequest.Username == "admin" && loginRequest.Password == "password")
            {
                var tokenResponse = await _jwtTokenService.GetToken(loginRequest.Username);
                return tokenResponse;
            }

            return null;
        }
    }
}
