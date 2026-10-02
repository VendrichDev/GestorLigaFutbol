using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorLigaFutbol.Models
{
    [Table("equipos")]
    public class Equipo
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre", TypeName = "varchar(50)")]
        [MaxLength(50, ErrorMessage = "El nombre del equipo no puede exceder los 50 caracteres")]
        [Required(ErrorMessage = "El nombre del equipo es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Column("ciudad", TypeName = "varchar(50)")]
        [MaxLength(50, ErrorMessage = "La ciudad del equipo no puede exceder los 50 caracteres")]
        [Required(ErrorMessage = "La ciudad del equipo es obligatoria")]
        public string Ciudad { get; set; } = string.Empty;


        [Column("anio_fundacion")]
        [Range(1880, 2100, ErrorMessage = "El año de fundación del equipo debe estar entre 1880 y el año actual")]
        public int AnioFundacion { get; set; }


        // Foreign key Liga

        [ForeignKey("liga")]
        [Column("liga_id")]
        public int LigaId { get; set; }
        public Liga? liga { get; set; }


        // Relaciones

        public List<Jugador>? Jugadores { get; set; } = new List<Jugador>();


        [InverseProperty("equipoLocal")]
        public List<Partido>? PartidosLocal { get; set; } = new List<Partido>();

        [InverseProperty("equipoVisitante")]
        public List<Partido>? PartidosVisitante { get; set; } = new List<Partido>();
    }
}
