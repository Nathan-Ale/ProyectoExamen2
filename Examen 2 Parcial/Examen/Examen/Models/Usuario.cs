using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Examen.Models
{
    [Table(name: "Usuario")]
    public class Usuario
    {
        [Key]
        [Column(name: "id")]
        public Guid Id { get; set; }

        [Column(name: "nombre")]
        public string Nombre { get; set; }

        [Column(name: "correo")]
        public string Correo { get; set; }

        [Column(name: "contrasena")]
        public string Contrasena { get; set; }

        [Column(name: "created_at")]
        public DateTime Created_At { get; set; }
    }
}
