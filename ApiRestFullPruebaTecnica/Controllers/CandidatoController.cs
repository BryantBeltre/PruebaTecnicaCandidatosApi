using ApiRestFullPruebaTecnica.Application.Commands.Candidatos;
using ApiRestFullPruebaTecnica.Application.DTOs.Candidatos;
using ApiRestFullPruebaTecnica.Application.Queries.Candidatos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

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
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCandidatosQuery();
            var candidatos = await _mediator.Send(query);
   
            return Ok(new {Message = "Operación exitosa.", StatusCode = 200, Data = candidatos });
        }

        //Obtener los candidatos por Id con la peticion GET api/candidatos{id}
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetCandidatoByIdQuery(id);
            var candidato = await _mediator.Send(query);
            if (candidato == null)
                return NotFound(new { Message = "$El candidato con ID {id} no encontrado" , StatusCode = 404});

            return Ok(new { Message = "Operación exitosa. ", StatusCode = 200, Data = candidato });

        }

        //Crear candidato con la peticion POST
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCandidatosDto createCandidatosDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new {Message ="Datos de entrada invalido "+ ModelState, StatusCode = 400});

            var command = new CreateCandidatoCommand { CreateCandidatosDto = createCandidatosDto };
            var created = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = created.Id },  new {Message = "Candidato creado con éxito.", StatusCode = 201, Data = created });
        }

        //Modificar los datos del candidato con la peticion put
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCandidatosDto updateCandidatosDto)
        {
            if (id != updateCandidatosDto.Id)
                return BadRequest("El dato de en trada no es valido.");

            if (!ModelState.IsValid)
                return BadRequest(new { Message = "Datos id de entrada invalidos.", StatusCode = 400 });

            var command = new UpdateCandidatoCommand { UpdateCandidatosDto = updateCandidatosDto };
            var updated = await _mediator.Send(command);
            if(updated == null) 
                return NotFound(new { Message = $"El ID {id} del candidato no fue encontrado.", StatusCode = 404});

            return Ok(new {Message = "Candidato actualizado con éxito.", StatusCode = 201, Data = updated });
        }

        //Eliminar candidato con la peticion DELETE
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) 
        {
            var command = new DeleteCandidatoCommand(id);
            var result = await _mediator.Send(command);

            if(!result)
                return NotFound(new { Message = $"Candidato con ID {id} no encontrado.", StatusCode = 404 });

            return Ok(new {Message = "Candidato eliminado co éxito.", StatusCode = 201, Data = result});
        }


    }
}
