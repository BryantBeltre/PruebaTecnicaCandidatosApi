using ApiRestFullPruebaTecnica.Application.Commands.Auth;
using ApiRestFullPruebaTecnica.Application.DTOs.Auth;
using ApiRestFullPruebaTecnica.Application.Interfaces.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestFullPruebaTecnica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new LoginCommand { LoginRequest = request };
            var tokenResponse = await _mediator.Send(command);

            if (tokenResponse == null)
                return Unauthorized(new { Message = "Credenciales inválidas." });

            return Ok(tokenResponse);
        }
    }
}
