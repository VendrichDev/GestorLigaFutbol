using Microsoft.AspNetCore.Mvc;
using GestorLigaFutbol.Models;
using GestorLigaFutbol.Consumer;

public class LigasController : Controller
{
    // GET: LIGAS
    public ActionResult Index()    
    {
        var ligas = CRUD<Liga>.GetAll();
        return View(ligas);
    }

    // GET: LIGAS/Details/5
    public ActionResult Details(int id)
    {
        var liga = CRUD<Liga>.GetById(id);
        if (liga == null)
        {
            return NotFound();            
        }
        return View(liga);
    }

    // GET: LIGAS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: LIGAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Liga liga)
    {
        try
        { 
            CRUD<Liga>.Create(liga);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error al crear la liga", ex.Message);
            return View(liga);
        }
    }

    // GET: LIGAS/Edit/5
    public ActionResult Edit(int id)
    {
        var liga = CRUD<Liga>.GetById(id);
        if (liga == null)
        {
            return NotFound();
        }
        return View(liga);
    }

    // POST: LIGAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Liga liga)
    {
        try
        { 
            CRUD<Liga>.Update(id, liga);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error al actualizar la liga", ex.Message);
            return View(liga);
        }
    }

    // GET: LIGAS/Delete/5
    public ActionResult Delete(int id)
    {
        var liga = CRUD<Liga>.GetById(id);
        if (liga == null)
        {
            return NotFound();
        }
        return View(liga);
    }

    // POST: LIGAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, Liga liga)
    {
        try
        {
            CRUD<Liga>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error al eliminar la liga", ex.Message);
            return View(liga);
        }
    }
}
