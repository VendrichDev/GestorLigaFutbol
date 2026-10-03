using Microsoft.AspNetCore.Mvc;
using GestorLigaFutbol.Models;
using GestorLigaFutbol.Consumer;

public class PartidosController : Controller
{
    // GET: PARTIDOS
    public ActionResult Index()    
    {
        var partidos = CRUD<Partido>.GetAll();
        return View(partidos);
    }

    // GET: PARTIDOS/Details/5
    public ActionResult Details(int id)
    {
        var partido = CRUD<Partido>.GetById(id);
        if (partido == null)
        {
            return NotFound();
        }
        return View(partido);
    }

    // GET: PARTIDOS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: PARTIDOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Partido partido)
    {
        try
        { 
           CRUD<Partido>.Create(partido);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error al Crear el partido", ex.Message);
            return View(partido);
        }
    }

    // GET: PARTIDOS/Edit/5
    public ActionResult Edit(int id)
    {
        var partido = CRUD<Partido>.GetById(id);
        if (partido == null)
        {
            return NotFound();
        }
        return View(partido);
    }

    // POST: PARTIDOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Partido partido)
    {
        try
        { 
            CRUD<Partido>.Update(id, partido);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error al Editar el partido", ex.Message);
            return View(partido);
        }
    }

    // GET: PARTIDOS/Delete/5
    public ActionResult Delete(int id)
    {
        var partido = CRUD<Partido>.GetById(id);
        if (partido == null)
        {
            return NotFound();
        }
        return View(partido);
    }

    // POST: PARTIDOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, Partido partido)
    {
        try
        {
            CRUD<Partido>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error al Eliminar el partido", ex.Message);
            return View(partido);
        }
    }
}
