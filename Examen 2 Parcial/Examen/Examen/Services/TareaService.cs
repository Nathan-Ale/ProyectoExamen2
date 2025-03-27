using Examen.Data;
using Examen.Models;
using Microsoft.EntityFrameworkCore;

namespace Examen.Services
{
    public class TareaService
    {
        private readonly DataContext _context;

        public TareaService(DataContext context)
        {
            _context = context;
        }

        // Obtener todos los recordatorios
        public async Task<List<Tarea>> ObtenerTodos()
        {
            return await _context.Tareas.ToListAsync();
        }

        // Obtener por ID
        public async Task<Tarea?> ObtenerPorId(Guid id)
        {
            return await _context.Tareas.FindAsync(id);
        }

        // Crear recordatorio
        public async Task<Tarea> Crear(Tarea tarea)
        {
            tarea.Id = Guid.NewGuid();

            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();

            return tarea;
        }

        // Actualizar recordatorio
        public async Task<bool> Actualizar(Guid id, Tarea recordatorioActualizado)
        {
            var recordatorio = await _context.Tareas.FindAsync(id);
            if (recordatorio == null) return false;

            // Actualiza solo los campos permitidos
            recordatorio.Titulo = recordatorioActualizado.Titulo;
            recordatorio.Descripcion = recordatorioActualizado.Descripcion;

            await _context.SaveChangesAsync();
            return true;
        }

        // Eliminar recordatorio
        public async Task<bool> Eliminar(Guid id)
        {
            var recordatorio = await _context.Tareas.FindAsync(id);
            if (recordatorio == null) return false;

            _context.Tareas.Remove(recordatorio);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
