using Microsoft.AspNetCore.Mvc;
using GestorLigaFutbol.Models;
using GestorLigaFutbol.Consumer;

public class EstadiosController : Controller
{
    // GET: ESTADIOS
    public ActionResult Index()    
    {
        var estadios = CRUD<Estadio>.GetAll();
        return View(estadios);
    }

    // GET: ESTADIOS/Details/5
    public ActionResult Details(int id)
    {
        var estadio = CRUD<Estadio>.GetById(id);
        if (estadio == null)
        {
            return NotFound();
        }
        return View(estadio);
    }

    // GET: ESTADIOS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: ESTADIOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Estadio estadio)
    {
        try
        {
            CRUD<Estadio>.Create(estadio);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        { 
            ModelState.AddModelError("Error al crear el estadio", ex.Message);
            return View(estadio);
        }
    }

    // GET: ESTADIOS/Edit/5
    public ActionResult Edit(int id)
    {
        var estadio = CRUD<Estadio>.GetById(id);
        if (estadio == null)
        {
            return NotFound();
        }
        return View(estadio);
    }

    // POST: ESTADIOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Estadio estadio)
    {
        try
        { 
            CRUD<Estadio>.Update(id, estadio);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error al actualizar el estadio", ex.Message);
            return View(estadio);
        }
    }

    // GET: ESTADIOS/Delete/5
    public IActionResult Delete(int id)
    {
        var estadio = CRUD<Estadio>.GetById(id);
        if (estadio == null)
        {
            return NotFound();
        }
        return View(estadio);
    }

    // POST: ESTADIOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, Estadio estadio)
    {
        try
        { 
            CRUD<Estadio>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error al eliminar el estadio", ex.Message);
            return View(estadio);
        }
    }
}
