using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestor_Notas.Models;
using Microsoft.AspNetCore.Authorization;

namespace Gestor_Notas.Controllers
{
    [Authorize]

    public class PeriodicidadsController : Controller
    {
        private readonly AC_ScoreContext _context;

        public PeriodicidadsController(AC_ScoreContext context)
        {
            _context = context;
        }

        // GET: Periodicidads
        public async Task<IActionResult> Index()
        {
              return View(await _context.Periodicidads.ToListAsync());
        }

        // GET: Periodicidads/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Periodicidads == null)
            {
                return NotFound();
            }

            var periodicidad = await _context.Periodicidads
                .FirstOrDefaultAsync(m => m.IdPeriodicidad == id);
            if (periodicidad == null)
            {
                return NotFound();
            }

            return View(periodicidad);
        }

        // GET: Periodicidads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Periodicidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPeriodicidad,Nombre,Descripcion")] Periodicidad periodicidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(periodicidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(periodicidad);
        }

        // GET: Periodicidads/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Periodicidads == null)
            {
                return NotFound();
            }

            var periodicidad = await _context.Periodicidads.FindAsync(id);
            if (periodicidad == null)
            {
                return NotFound();
            }
            return View(periodicidad);
        }

        // POST: Periodicidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdPeriodicidad,Nombre,Descripcion")] Periodicidad periodicidad)
        {
            if (id != periodicidad.IdPeriodicidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(periodicidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeriodicidadExists(periodicidad.IdPeriodicidad))
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
            return View(periodicidad);
        }

        // GET: Periodicidads/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Periodicidads == null)
            {
                return NotFound();
            }

            var periodicidad = await _context.Periodicidads
                .FirstOrDefaultAsync(m => m.IdPeriodicidad == id);
            if (periodicidad == null)
            {
                return NotFound();
            }

            return View(periodicidad);
        }

        // POST: Periodicidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Periodicidads == null)
            {
                return Problem("Entity set 'AC_ScoreContext.Periodicidads'  is null.");
            }
            var periodicidad = await _context.Periodicidads.FindAsync(id);
            if (periodicidad != null)
            {
                _context.Periodicidads.Remove(periodicidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeriodicidadExists(string id)
        {
          return _context.Periodicidads.Any(e => e.IdPeriodicidad == id);
        }
    }
}
