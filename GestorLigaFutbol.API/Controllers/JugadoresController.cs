using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestorLigaFutbol.Models;

[Route("api/[controller]")]
[ApiController]
public class JugadoresController : ControllerBase
{
    private readonly GestorLigaFutbolAPIContext _context;
    public JugadoresController(GestorLigaFutbolAPIContext context)
    {
        _context = context;
    }

    // GET: api/Jugador
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Jugador>>> GetJugador()
    {
        var jugadores = await _context.Jugadores.
            Include(j => j.equipo).
            Include(j => j.Goles)
            .AsNoTracking()
            .ToListAsync(); ;
        return jugadores;
    }

    // GET: api/Jugador/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Jugador>> GetJugador(int id)
    {
        var jugador = await _context.Jugadores.FindAsync(id);

        if (jugador == null)
        {
            return NotFound();
        }

        return jugador;
    }

    // PUT: api/Jugador/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutJugador(int? id, Jugador jugador)
    {
        if (id != jugador.Id)
        {
            return BadRequest();
        }

        _context.Entry(jugador).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!JugadorExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Jugador
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Jugador>> PostJugador(Jugador jugador)
    {
        _context.Jugadores.Add(jugador);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetJugador", new { id = jugador.Id }, jugador);
    }

    // DELETE: api/Jugador/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJugador(int? id)
    {
        var jugador = await _context.Jugadores.FindAsync(id);
        if (jugador == null)
        {
            return NotFound();
        }

        _context.Jugadores.Remove(jugador);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool JugadorExists(int? id)
    {
        return _context.Jugadores.Any(e => e.Id == id);
    }
}
