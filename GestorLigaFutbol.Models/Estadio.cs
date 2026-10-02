using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorLigaFutbol.Models
{
    [Table("estadios")]
    public class Estadio
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre", TypeName = "varchar(100)")]
        [MaxLength(100, ErrorMessage = "El nombre del estadio no puede exceder los 100 caracteres")]
        [Required(ErrorMessage = "El nombre del estadio es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Column("ciudad", TypeName = "varchar(50)")]
        [MaxLength(50, ErrorMessage = "La ciudad del estadio no puede exceder los 50 caracteres")]
        [Required(ErrorMessage = "La ciudad del estadio es obligatoria")]
        public string Ciudad { get; set; } = string.Empty;

        [Column("capacidad")]
        [Range(1, int.MaxValue, ErrorMessage = "La capacidad del estadio debe ser un valor positivo")]
        public int Capacidad { get; set; }


        // relaciones

        public List<Partido>? Partidos { get; set; } = new List<Partido>();
    }
}
