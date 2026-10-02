using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorLigaFutbol.Models
{
    [Table("ligas")]
    public class Liga
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }


        [Column("nombre", TypeName = "varchar(100)")]
        [MaxLength(100, ErrorMessage = "El nombre de la liga no puede exceder los 100 caracteres")]
        [Required(ErrorMessage = "El nombre de la liga es obligatorio")]
        public string Nombre { get; set; } = string.Empty;


        [Column("pais", TypeName = "varchar(50)")]
        [MaxLength(50, ErrorMessage = "El país de la liga no puede exceder los 50 caracteres")]
        [Required(ErrorMessage = "El país de la liga es obligatorio")]
        public string Pais { get; set; } = string.Empty;

        [Column("temporada", TypeName = "varchar(22)")]
        [MaxLength(22, ErrorMessage = "La temporada de la liga no puede exceder los 22 caracteres")]
        [Required(ErrorMessage = "La temporada de la liga es obligatoria")]
        public string Temporada { get; set; } = string.Empty;


        // Relaciones 
        public List<Equipo>? Equipos { get; set; } = new List<Equipo>();
    }
}
