using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestor_Notas.Models;

namespace Gestor_Notas.Controllers
{
    public class CarrerasController : Controller
    {
        private readonly AC_ScoreContext _context;

        public CarrerasController(AC_ScoreContext context)
        {
            _context = context;
        }

        // GET: Carreras
        public async Task<IActionResult> Index()
        {

            if (User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Administrador")
            {
                var aC_ScoreContext = _context.Carreras.Include(c => c.IdSedeNavigation);
                return View(await aC_ScoreContext.ToListAsync());
            }
            else
            {
                return RedirectToAction("Index", "Error", new { data = "Error de acceso!!", data2 = "Usted no cuenta con los permisos necesario" });

            }

            }

        // GET: Carreras/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Administrador")
            {
                if (id == null || _context.Carreras == null)
            {
                return NotFound();
            }

            var carrera = await _context.Carreras
                .Include(c => c.IdSedeNavigation)
                .FirstOrDefaultAsync(m => m.IdCarrera == id);
            if (carrera == null)
            {
                return NotFound();
            }

            return View(carrera);
            }
            else
            {
                return RedirectToAction("Index", "Error", new { data = "Error de acceso!!", data2 = "Usted no cuenta con los permisos necesario" });

            }
        }

        // GET: Carreras/Create
        public IActionResult Create()
        {
            if (User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Administrador")
            {
                ViewData["IdSede"] = new SelectList(_context.Sedes, "IdSede", "Sede1");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Error", new { data = "Error de acceso!!", data2 = "Usted no cuenta con los permisos necesario" });

            }
            }

        // POST: Carreras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCarrera,Carrera1,IdSede")] Carrera carrera)
        {
            if (User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Administrador")
            {
                if (ModelState.IsValid)
                {
                    _context.Add(carrera);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdSede"] = new SelectList(_context.Sedes, "IdSede", "IdSede", carrera.IdSede);
                return View(carrera);
            }
            else
            {
                return RedirectToAction("Index", "Error", new { data = "Error de acceso!!", data2 = "Usted no cuenta con los permisos necesario" });

            }
            }

        // GET: Carreras/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Administrador")
            {
                if (id == null || _context.Carreras == null)
                {
                    return NotFound();
                }

                var carrera = await _context.Carreras.FindAsync(id);
                if (carrera == null)
                {
                    return NotFound();
                }
                ViewData["IdSede"] = new SelectList(_context.Sedes, "IdSede", "Sede1", carrera.IdSede);
                return View(carrera);
            }
            else
            {
                return RedirectToAction("Index", "Error", new { data = "Error de acceso!!", data2 = "Usted no cuenta con los permisos necesario" });

            }
            }

        // POST: Carreras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdCarrera,Carrera1,IdSede")] Carrera carrera)
        {
            if (User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Administrador")
            {
                if (id != carrera.IdCarrera)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(carrera);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CarreraExists(carrera.IdCarrera))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdSede"] = new SelectList(_context.Sedes, "IdSede", "IdSede", carrera.IdSede);
                return View(carrera);
            }
            else
            {
                return RedirectToAction("Index", "Error", new { data = "Error de acceso!!", data2 = "Usted no cuenta con los permisos necesario" });

            }
            }

        // GET: Carreras/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Administrador")
            {
                if (id == null || _context.Carreras == null)
                {
                    return NotFound();
                }

                var carrera = await _context.Carreras
                    .Include(c => c.IdSedeNavigation)
                    .FirstOrDefaultAsync(m => m.IdCarrera == id);
                if (carrera == null)
                {
                    return NotFound();
                }

                return View(carrera);
            }
            else
            {
                return RedirectToAction("Index", "Error", new { data = "Error de acceso!!", data2 = "Usted no cuenta con los permisos necesario" });

            }
            }

        // POST: Carreras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Administrador")
            {
                try
                {
                    if (_context.Carreras == null)
                    {
                        return Problem("Entity set 'AC_ScoreContext.Carreras'  is null.");
                    }
                    var carrera = await _context.Carreras.FindAsync(id);
                    if (carrera != null)
                    {
                        _context.Carreras.Remove(carrera);
                    }

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return RedirectToAction("Index", "Error", new { data = "Error al eliminar Carrera!!", data2 = "Este campo esta siendo utilizado" });

                }
            }
            else
            {
                return RedirectToAction("Index", "Error", new { data = "Error de acceso!!", data2 = "Usted no cuenta con los permisos necesario" });

            }
            }

        private bool CarreraExists(string id)
        {
          return _context.Carreras.Any(e => e.IdCarrera == id);
        }
    }
}
