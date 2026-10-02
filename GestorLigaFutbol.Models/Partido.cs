using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorLigaFutbol.Models
{
    [Table("partidos")]
    public class Partido
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("fecha_hora", TypeName = "timestamp")]
        [Required(ErrorMessage = "La fecha y hora del partido es obligatoria")]
        public DateTime FechaHora { get; set; }


        [Column("goles_local")]
        public int GolesLocal { get; set; } = 0;

        [Column("goles_visitante")]
        public int GolesVisitante { get; set; } = 0;

        [Column("jugado")]
        public bool Jugado { get; set; } = false;

        // Foreign key EquipoLocal
        [ForeignKey("equipoLocal")]
        [Column("equipo_local_id")]
        public int EquipoLocalId { get; set; }
        public Equipo? equipoLocal { get; set; }

        // Foreign key EquipoVisitante
        [ForeignKey("equipoVisitante")]
        [Column("equipo_visitante_id")]
        public int EquipoVisitanteId { get; set; }
        public Equipo? equipoVisitante { get; set; }

        // Foreign key Estadio
        [ForeignKey("estadio")]
        [Column("estadio_id")]
        public int EstadioId { get; set; }
        public Estadio? estadio { get; set; }


        // relaciones

        public List<Gol>? Goles { get; set; } = new List<Gol>();
    }
}
