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
    public class SedesController : Controller
    {
        private readonly AC_ScoreContext _context;

        public SedesController(AC_ScoreContext context)
        {
            _context = context;
        }

        // GET: Sedes

        public async Task<IActionResult> Index()
        
        {

            if (User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Administrador")
            { 
                return View(await _context.Sedes.ToListAsync());
            }
            else
            {
                return RedirectToAction("Index", "Error", new { data = "Error de acceso!!", data2 = "Usted no cuenta con los permisos necesario" });

            }


        }

        // GET: Sedes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Administrador")
            {
                if (id == null || _context.Sedes == null)
                {
                    return NotFound();
                }

                var sede = await _context.Sedes
                    .FirstOrDefaultAsync(m => m.IdSede == id);
                if (sede == null)
                {
                    return NotFound();
                }

                return View(sede);
            }
            else
            {
                return RedirectToAction("Index", "Error", new { data = "Error de acceso!!", data2 = "Usted no cuenta con los permisos necesario" });

            }
        }

            // GET: Sedes/Create
            public IActionResult Create()
        {
            if (User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Administrador")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Error", new { data = "Error de acceso!!", data2 = "Usted no cuenta con los permisos necesario" });

            }
        }

        // POST: Sedes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSede,Sede1")] Sede sede)
        {
            if (User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Administrador")
            {
                if (User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Administrador")
            {
                if (ModelState.IsValid)
                {
                    _context.Add(sede);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(sede);
            }
            else
            {
                return RedirectToAction("Index", "Error", new { data = "Error de acceso!!", data2 = "Usted no cuenta con los permisos necesario" });

            }
            }
            else
            {
                return RedirectToAction("Index", "Error", new { data = "Error de acceso!!", data2 = "Usted no cuenta con los permisos necesario" });

            }
        }

        // GET: Sedes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {

            if (User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Administrador")
            {
                if (id == null || _context.Sedes == null)
                {
                    return NotFound();
                }

                var sede = await _context.Sedes.FindAsync(id);
                if (sede == null)
                {
                    return NotFound();
                }
                return View(sede);
            }
            else
            {
                return RedirectToAction("Index", "Error", new { data = "Error de acceso!!", data2 = "Usted no cuenta con los permisos necesario" });

            }
            }

        // POST: Sedes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdSede,Sede1")] Sede sede)
        {
            if (User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Administrador")
            {
                if (id != sede.IdSede)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sede);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SedeExists(sede.IdSede))
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
            return View(sede);
            }
            else
            {
                return RedirectToAction("Index", "Error", new { data = "Error de acceso!!", data2 = "Usted no cuenta con los permisos necesario" });

            }
        }

        // GET: Sedes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Administrador")
            {
                if (id == null || _context.Sedes == null)
            {
                return NotFound();
            }

            var sede = await _context.Sedes
                .FirstOrDefaultAsync(m => m.IdSede == id);
            if (sede == null)
            {
                return NotFound();
            }

            return View(sede);
            }
            else
            {
                return RedirectToAction("Index", "Error", new { data = "Error de acceso!!", data2 = "Usted no cuenta con los permisos necesario" });

            }
        }

        // POST: Sedes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Administrador")
            {
                try
            {
                if (_context.Sedes == null)
                {
                    return Problem("Entity set 'AC_ScoreContext.Sedes'  is null.");
                }
                var sede = await _context.Sedes.FindAsync(id);
                if (sede != null)
                {
                    _context.Sedes.Remove(sede);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Index", "Error", new { data = "Error al eliminar Sede!!", data2 = "Este campo esta siendo utilizado" });

            }
            }
            else
            {
                return RedirectToAction("Index", "Error", new { data = "Error de acceso!!", data2 = "Usted no cuenta con los permisos necesario" });

            }
        }

        private bool SedeExists(string id)
        {
          return _context.Sedes.Any(e => e.IdSede == id);
        }
    }
}
