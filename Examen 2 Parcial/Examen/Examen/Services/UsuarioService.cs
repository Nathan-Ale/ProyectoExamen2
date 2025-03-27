using Microsoft.EntityFrameworkCore;
using Examen.Data;
using Examen.Models;

namespace Examen.Services
{
    public class UsuarioService
    {
        private readonly DataContext _context;

        public UsuarioService(DataContext context)
        {
            _context = context;
        }

        //----------------------------------------------------------------------------------
        //Obtener todos los usuarios
        public async Task<List<Usuario>> ObtenerUsuario()
        {
            return await _context.Usuarios.ToListAsync();
        }

        //Obtener usuario por id
        public async Task<Usuario?> ObtenerUsuarioPorId(Guid id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        //Crear un usuario
        public async Task<Usuario> CrearUsuario(Usuario usuario)
        {
            usuario.Id = Guid.NewGuid();
            usuario.Created_At = DateTime.UtcNow;

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        //actualizar un usuario
        public async Task<bool> ActualizarUsuario(Guid id, Usuario usuarioActualizado)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return false;

            usuario.Nombre = usuarioActualizado.Nombre;
            usuario.Correo = usuarioActualizado.Correo;
            usuario.Contrasena = usuarioActualizado.Contrasena;

            await _context.SaveChangesAsync();
            return true;
        }

        //eliminar un usuario
        public async Task<bool> EliminarUsuario(Guid id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
