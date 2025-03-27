using Examen.Models;
using Examen.Services;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Controllers
{
    [Route(template: "api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly TareaService _service;

        public TareasController(TareaService service)
        {
            _service = service;
        }

        // GET: api/recordatorios
        [HttpGet]
        public async Task<ActionResult<List<Tarea>>> GetAll()
        {
            return Ok(await _service.ObtenerTodos());
        }

        // GET: api/recordatorios/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarea>> GetById(Guid id)
        {
            var recordatorio = await _service.ObtenerPorId(id);
            if (recordatorio == null) return NotFound("Tarea no encontrada");
            return Ok(recordatorio);
        }

        // POST: api/recordatorios
        [HttpPost]
        public async Task<ActionResult<Tarea>> Create([FromBody] Tarea recordatorio)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var nuevoRecordatorio = await _service.Crear(recordatorio);
            return CreatedAtAction(nameof(GetById), new { id = nuevoRecordatorio.Id }, nuevoRecordatorio);
        }

        // PUT: api/recordatorios/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Tarea recordatorio)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var resultado = await _service.Actualizar(id, recordatorio);
            if (!resultado) return NotFound("Tarea no encontrada");
            return NoContent();
        }

        // DELETE: api/recordatorios/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var resultado = await _service.Eliminar(id);
            if (!resultado) return NotFound("Tarea no encontrada");
            return NoContent();
        }
    }
}
