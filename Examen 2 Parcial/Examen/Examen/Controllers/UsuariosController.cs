using Examen.Models;
using Examen.Services;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Controllers
{
    [Route(template: "api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuariosController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> ObtenerUsuario()
        {
            var usuarios = await _usuarioService.ObtenerUsuario();
            return Ok(usuarios);
        }

        [HttpGet(template: "{id}")]
        public async Task<ActionResult<Usuario>> ObtenerUsuarioPorId(Guid id)
        {
            var usuario = await _usuarioService.ObtenerUsuarioPorId(id);
            if (usuario == null) return NotFound("usuario no encontrado");

            return Ok(usuario);
        }
        [HttpPost]
        public async Task<ActionResult> CrearUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest(error: "Datos de usuario vienen vacios");
            }

            var nuevoUsuario = await _usuarioService.CrearUsuario(usuario);
            return Ok(nuevoUsuario);
        }

        [HttpPut(template: "{id}")]
        public async Task<ActionResult> ActualizarUsuario(Guid id, [FromBody] Usuario usuarioActualizado)
        {
            if (usuarioActualizado == null)
            {
                return BadRequest(error: "Datos de usuario vienen vacios");
            }

            var response = await _usuarioService.ActualizarUsuario(id, usuarioActualizado);

            if (response == false)
            {
                return NotFound("Usuario no encontrado en base de datos");
            }

            return NoContent();
        }

        [HttpDelete(template: "{id}")]
        public async Task<ActionResult> EliminarUsuario(Guid id)
        {
            var response = await _usuarioService.EliminarUsuario(id);
            if (response == false)
            {
                return NotFound("Usuario no encontrado en base de datos");
            }
            return NoContent();
        }
    }
}
