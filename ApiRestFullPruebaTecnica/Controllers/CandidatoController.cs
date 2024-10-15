using ApiRestFullPruebaTecnica.Application.Commands.Candidatos;
using ApiRestFullPruebaTecnica.Application.DTOs.Candidatos;
using ApiRestFullPruebaTecnica.Application.Queries.Candidatos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestFullPruebaTecnica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CandidatoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Obtener los candidatos con la peticion GET :  api/candidatos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCandidatosQuery();
            var candidatos = await _mediator.Send(query);
            return Ok(candidatos);
        }

        //Obtener los candidatos por Id con la peticion GET api/candidatos{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetCandidatoByIdQuery(id);
            var candidato = await _mediator.Send(query);
            if (candidato == null)
                return NotFound();

            return Ok(candidato);

        }

        //Crear candidato con la peticion POST
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCandidatosDto createCandidatosDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateCandidatoCommand { CreateCandidatosDto = createCandidatosDto };
            var created = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        //Modificar los datos del candidato con la peticion put
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCandidatosDto updateCandidatosDto)
        {
            if (id != updateCandidatosDto.Id)
                return BadRequest("El ID del candidato no coincide.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new UpdateCandidatoCommand { UpdateCandidatosDto = updateCandidatosDto };
            var updated = await _mediator.Send(command);
            if(updated == null) 
                return NotFound();

            return Ok(updated);
        }

        //Eliminar candidato con la peticion DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) 
        {
            var command = new DeleteCandidatoCommand(id);
            var result = await _mediator.Send(command);

            if(!result)
                return NotFound();

            return Ok(result);
        }


    }
}
