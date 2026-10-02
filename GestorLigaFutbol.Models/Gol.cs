using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorLigaFutbol.Models
{
    [Table("goles")]
    public class Gol
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("minuto")]
        [Range(1, 120, ErrorMessage = "El minuto del gol debe estar entre 1 y 120")]
        public int Minuto { get; set; }

        // Foreign key Partido
        [ForeignKey("partido")]
        [Column("partido_id")]
        public int PartidoId { get; set; }
        public Partido? partido { get; set; }

        // Foreign key Jugador
        [ForeignKey("jugador")]
        [Column("jugador_id")]
        public int JugadorId { get; set; }
        public Jugador? jugador { get; set; }
    }
}
