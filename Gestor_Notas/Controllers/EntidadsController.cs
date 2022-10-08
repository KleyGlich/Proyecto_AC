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

    public class EntidadsController : Controller
    {
        private readonly AC_ScoreContext _context;

        public EntidadsController(AC_ScoreContext context)
        {
            _context = context;
        }

        // GET: Entidads
        public async Task<IActionResult> Index()
        {
              return View(await _context.Entidads.ToListAsync());
        }

        // GET: Entidads/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Entidads == null)
            {
                return NotFound();
            }

            var entidad = await _context.Entidads
                .FirstOrDefaultAsync(m => m.IdRol == id);
            if (entidad == null)
            {
                return NotFound();
            }

            return View(entidad);
        }

        // GET: Entidads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRol,Nombre,Descripcion")] Entidad entidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entidad);
        }

        // GET: Entidads/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Entidads == null)
            {
                return NotFound();
            }

            var entidad = await _context.Entidads.FindAsync(id);
            if (entidad == null)
            {
                return NotFound();
            }
            return View(entidad);
        }

        // POST: Entidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdRol,Nombre,Descripcion")] Entidad entidad)
        {
            if (id != entidad.IdRol)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntidadExists(entidad.IdRol))
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
            return View(entidad);
        }

        // GET: Entidads/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Entidads == null)
            {
                return NotFound();
            }

            var entidad = await _context.Entidads
                .FirstOrDefaultAsync(m => m.IdRol == id);
            if (entidad == null)
            {
                return NotFound();
            }

            return View(entidad);
        }

        // POST: Entidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Entidads == null)
            {
                return Problem("Entity set 'AC_ScoreContext.Entidads'  is null.");
            }
            var entidad = await _context.Entidads.FindAsync(id);
            if (entidad != null)
            {
                _context.Entidads.Remove(entidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntidadExists(string id)
        {
          return _context.Entidads.Any(e => e.IdRol == id);
        }
    }
}
