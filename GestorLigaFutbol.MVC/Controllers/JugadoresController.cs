using Microsoft.AspNetCore.Mvc;
using GestorLigaFutbol.Models;
using GestorLigaFutbol.Consumer;

public class JugadoresController : Controller
{
    // GET: JUGADORS
    public ActionResult Index()    
    {
        var jugadores = CRUD<Jugador>.GetAll();
        return View(jugadores);
    }

    // GET: JUGADORS/Details/5
    public ActionResult Details(int id)
    {
        var jugador = CRUD<Jugador>.GetById(id);
        if (jugador == null)
        {
            return NotFound();
        }
        return View(jugador);
    }

    // GET: JUGADORS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: JUGADORS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Jugador jugador)
    {
        try
        { 
            CRUD<Jugador>.Create(jugador);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error al crear el jugador", ex.Message);
            return View(jugador);
        }
    }

    // GET: JUGADORS/Edit/5
    public ActionResult Edit(int id)
    {
        var jugador = CRUD<Jugador>.GetById(id);
        if (jugador == null)
        {
            return NotFound();
        }
        return View(jugador);
    }

    // POST: JUGADORS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Jugador jugador)
    {
        try
        { 
            CRUD<Jugador>.Update(id, jugador);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error al actualizar el jugador", ex.Message);
            return View(jugador);
        }
    }

    // GET: JUGADORS/Delete/5
    public ActionResult Delete(int id)
    {
        var jugador = CRUD<Jugador>.GetById(id);
        if (jugador == null)
        {
            return NotFound();
        }
        return View(jugador);
    }

    // POST: JUGADORS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, Jugador jugador)
    {
        try
        {
            CRUD<Jugador>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error al eliminar el jugador", ex.Message);
            return View(jugador);
        }
    }
}
