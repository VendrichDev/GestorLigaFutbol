using Microsoft.EntityFrameworkCore;

public class GestorLigaFutbolAPIContext(DbContextOptions<GestorLigaFutbolAPIContext> options) : DbContext(options)
{
    public DbSet<GestorLigaFutbol.Models.Equipo> Equipos { get; set; } = default!;
    public DbSet<GestorLigaFutbol.Models.Liga> Ligas { get; set; } = default!;
    public DbSet<GestorLigaFutbol.Models.Gol> Goles { get; set; } = default!;
    public DbSet<GestorLigaFutbol.Models.Jugador> Jugadores { get; set; } = default!;
    public DbSet<GestorLigaFutbol.Models.Estadio> Estadios { get; set; } = default!;
    public DbSet<GestorLigaFutbol.Models.Partido> Partidos { get; set; } = default!;
}
