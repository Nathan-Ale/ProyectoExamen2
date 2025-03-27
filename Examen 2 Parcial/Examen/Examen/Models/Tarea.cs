using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Examen.Models
{
    [Table(name: "Tarea")]
    public class Tarea
    {
        [Key]
        [Column(name: "id")]
        public Guid Id { get; set; }

        [Column(name: "titulo")]
        public string Titulo { get; set; }

        [Column(name: "descripcion")]
        public string Descripcion { get; set; }
    }
}
