using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestorLigaFutbol.Models;

[Route("api/[controller]")]
[ApiController]
public class PartidosController : ControllerBase
{
    private readonly GestorLigaFutbolAPIContext _context;
    public PartidosController(GestorLigaFutbolAPIContext context)
    {
        _context = context;
    }

    // GET: api/Partido
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Partido>>> GetPartido()
    {
        var partidos = await _context.Partidos.
            Include(p => p.equipoLocal).
            Include(p => p.equipoVisitante).
            Include(p => p.estadio).
            Include(p => p.Goles)
            .ToListAsync();
        return partidos;
    }

    // GET: api/Partido/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Partido>> GetPartido(int id)
    {
        var partido = await _context.Partidos.FindAsync(id);

        if (partido == null)
        {
            return NotFound();
        }

        return partido;
    }

    // PUT: api/Partido/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPartido(int? id, Partido partido)
    {
        if (id != partido.Id)
        {
            return BadRequest();
        }

        _context.Entry(partido).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PartidoExists(id))
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

    // POST: api/Partido
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Partido>> PostPartido(Partido partido)
    {
        _context.Partidos.Add(partido);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPartido", new { id = partido.Id }, partido);
    }

    // DELETE: api/Partido/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePartido(int? id)
    {
        var partido = await _context.Partidos.FindAsync(id);
        if (partido == null)
        {
            return NotFound();
        }

        _context.Partidos.Remove(partido);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PartidoExists(int? id)
    {
        return _context.Partidos.Any(e => e.Id == id);
    }
}
