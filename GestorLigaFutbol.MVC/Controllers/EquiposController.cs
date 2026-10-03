using Microsoft.AspNetCore.Mvc;
using GestorLigaFutbol.Models;
using GestorLigaFutbol.Consumer;

public class EquiposController : Controller
{
    // GET: EQUIPOS
    public ActionResult Index()    
    {
        var equipos = CRUD<Equipo>.GetAll();
        return View(equipos);
    }

    // GET: EQUIPOS/Details/5
    public ActionResult Details(int id)
    {
        var equipo = CRUD<Equipo>.GetById(id);
        if (equipo == null)
        {
            return NotFound();
        }
        return View(equipo);
    }

    // GET: EQUIPOS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: EQUIPOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create( Equipo equipo)
    {
        try
        { 
            CRUD<Equipo>.Create(equipo);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error al crear el equipo", ex.Message);
            return View(equipo);
        }
    }

    // GET: EQUIPOS/Edit/5
    public ActionResult Edit(int id)
    {
        var equipo = CRUD<Equipo>.GetById(id);
        if (equipo == null)
        {
            return NotFound();
        }
        return View(equipo);
    }

    // POST: EQUIPOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Equipo equipo)
    {
        try
        { 
            CRUD<Equipo>.Update(id, equipo);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error al editar el equipo", ex.Message);
            return View(equipo);
        }
    }

    // GET: EQUIPOS/Delete/5
    public ActionResult Delete(int id)
    {
        var equipo = CRUD<Equipo>.GetById(id);
        if (equipo == null)
        {
            return NotFound();
        }
        return View(equipo);
    }

    // POST: EQUIPOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, Equipo equipo)
    {
        try
        { 
            CRUD<Equipo>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error al eliminar el equipo", ex.Message);
            return View(equipo);
        }
    }
}
