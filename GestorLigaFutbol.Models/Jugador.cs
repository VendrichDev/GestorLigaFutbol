using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorLigaFutbol.Models
{
    [Table("jugadores")]
    public class Jugador
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre", TypeName = "varchar(50)")]
        [MaxLength(50, ErrorMessage = "El nombre del jugador no puede exceder los 50 caracteres")]
        [Required(ErrorMessage = "El nombre del jugador es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Column("apellido", TypeName = "varchar(50)")]
        [MaxLength(50, ErrorMessage = "El apellido del jugador no puede exceder los 50 caracteres")]
        [Required(ErrorMessage = "El apellido del jugador es obligatorio")]
        public string Apellido { get; set; } = string.Empty;

        [Column("posicion", TypeName = "varchar(20)")]

        public PosicionCampo Posicion { get; set; }

        [Column("dorsal_camisa")]
        [Range(1, 99, ErrorMessage = "El dorsal de la camisa debe estar entre 1 y 99")]
        public int DorsalCamisa { get; set; }

        // Foreign key Equipo
        [ForeignKey("equipo")]
        [Column("equipo_id")]
        public int EquipoId { get; set; }
        public Equipo? equipo { get; set; }


        // Relaciones
        public List<Gol>? Goles { get; set; } = new List<Gol>();
    }
}