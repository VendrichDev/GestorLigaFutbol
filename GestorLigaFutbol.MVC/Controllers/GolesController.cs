using Microsoft.AspNetCore.Mvc;
using GestorLigaFutbol.Models;
using GestorLigaFutbol.Consumer;

public class GolesController : Controller
{
    // GET: GOLS
    public ActionResult Index()    
    {
        var goles = CRUD<Gol>.GetAll();
        return View(goles);
    }

    // GET: GOLS/Details/5
    public ActionResult Details(int id)
    {
        var gol = CRUD<Gol>.GetById(id);
        if (gol == null)
        {
            return NotFound();
        }
        return View(gol);
    }

    // GET: GOLS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: GOLS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Gol gol)
    {
        try
        { 
            CRUD<Gol>.Create(gol);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error al crear el gol", ex.Message);
            return View(gol);
        }
    }

    // GET: GOLS/Edit/5
    public ActionResult Edit(int id)
    {
        var gol = CRUD<Gol>.GetById(id);
        if (gol == null)
        {
            return NotFound();
        }
        return View(gol);
    }

    // POST: GOLS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Gol gol)
    {
        try
        { 
            CRUD<Gol>.Update(id, gol);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error al actualizar el gol", ex.Message);
            return View(gol);
        }
    }

    // GET: GOLS/Delete/5
    public ActionResult Delete(int id)
    {
        var gol = CRUD<Gol>.GetById(id);
        if (gol == null)
        {
            return NotFound();
        }
        return View(gol);
    }

    // POST: GOLS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, Gol gol)
    {
        try
        {
            CRUD<Gol>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error al eliminar el gol", ex.Message);
            return View(gol);
        }
    }
}
