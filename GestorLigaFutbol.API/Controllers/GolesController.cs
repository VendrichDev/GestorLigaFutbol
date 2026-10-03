using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestorLigaFutbol.Models;

[Route("api/[controller]")]
[ApiController]
public class GolesController : ControllerBase
{
    private readonly GestorLigaFutbolAPIContext _context;
    public GolesController(GestorLigaFutbolAPIContext context)
    {
        _context = context;
    }

    // GET: api/Gol
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Gol>>> GetGol()
    {
        var goles = await _context.Goles
            .Include(g => g.jugador)
            .Include(g => g.partido)
            .AsNoTracking()
            .ToListAsync(); 
        return goles;
    }

    // GET: api/Gol/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Gol>> GetGol(int id)
    {
        var gol = await _context.Goles.FindAsync(id);

        if (gol == null)
        {
            return NotFound();
        }

        return gol;
    }

    // PUT: api/Gol/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutGol(int? id, Gol gol)
    {
        if (id != gol.Id)
        {
            return BadRequest();
        }

        _context.Entry(gol).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!GolExists(id))
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

    // POST: api/Gol
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Gol>> PostGol(Gol gol)
    {
        _context.Goles.Add(gol);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetGol", new { id = gol.Id }, gol);
    }

    // DELETE: api/Gol/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGol(int? id)
    {
        var gol = await _context.Goles.FindAsync(id);
        if (gol == null)
        {
            return NotFound();
        }

        _context.Goles.Remove(gol);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool GolExists(int? id)
    {
        return _context.Goles.Any(e => e.Id == id);
    }
}
