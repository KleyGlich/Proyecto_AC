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
    public class EstudianteCarrerasController : Controller
    {
        private readonly AC_ScoreContext _context;

        public EstudianteCarrerasController(AC_ScoreContext context)
        {
            _context = context;
        }

        // GET: EstudianteCarreras
        public async Task<IActionResult> Index()
        {
            var aC_ScoreContext = _context.EstudianteCarreras.Include(e => e.EstudianteNavigation).Include(e => e.IdCarreraNavigation);
            return View(await aC_ScoreContext.ToListAsync());
        }

        // GET: EstudianteCarreras/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.EstudianteCarreras == null)
            {
                return NotFound();
            }

            var estudianteCarrera = await _context.EstudianteCarreras
                .Include(e => e.EstudianteNavigation)
                .Include(e => e.IdCarreraNavigation)
                .FirstOrDefaultAsync(m => m.IdEstu == id);
            if (estudianteCarrera == null)
            {
                return NotFound();
            }

            return View(estudianteCarrera);
        }

        // GET: EstudianteCarreras/Create
        public IActionResult Create()
        {
            ViewData["Estudiante"] = new SelectList(_context.Estudiantes, "IdUsuario", "PrimerNombre");
            ViewData["IdCarrera"] = new SelectList(_context.Carreras, "IdCarrera", "Carrera1");
            return View();
        }

        // POST: EstudianteCarreras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstu,IdCarrera,Estudiante")] EstudianteCarrera estudianteCarrera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudianteCarrera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Estudiante"] = new SelectList(_context.Estudiantes, "IdUsuario", "IdUsuario", estudianteCarrera.Estudiante);
            ViewData["IdCarrera"] = new SelectList(_context.Carreras, "IdCarrera", "IdCarrera", estudianteCarrera.IdCarrera);
            return View(estudianteCarrera);
        }

        // GET: EstudianteCarreras/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.EstudianteCarreras == null)
            {
                return NotFound();
            }

            var estudianteCarrera = await _context.EstudianteCarreras.FindAsync(id);
            if (estudianteCarrera == null)
            {
                return NotFound();
            }
            ViewData["Estudiante"] = new SelectList(_context.Estudiantes, "IdUsuario", "IdUsuario", estudianteCarrera.Estudiante);
            ViewData["IdCarrera"] = new SelectList(_context.Carreras, "IdCarrera", "IdCarrera", estudianteCarrera.IdCarrera);
            return View(estudianteCarrera);
        }

        // POST: EstudianteCarreras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdEstu,IdCarrera,Estudiante")] EstudianteCarrera estudianteCarrera)
        {
            if (id != estudianteCarrera.IdEstu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudianteCarrera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteCarreraExists(estudianteCarrera.IdEstu))
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
            ViewData["Estudiante"] = new SelectList(_context.Estudiantes, "IdUsuario", "IdUsuario", estudianteCarrera.Estudiante);
            ViewData["IdCarrera"] = new SelectList(_context.Carreras, "IdCarrera", "IdCarrera", estudianteCarrera.IdCarrera);
            return View(estudianteCarrera);
        }

        // GET: EstudianteCarreras/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.EstudianteCarreras == null)
            {
                return NotFound();
            }

            var estudianteCarrera = await _context.EstudianteCarreras
                .Include(e => e.EstudianteNavigation)
                .Include(e => e.IdCarreraNavigation)
                .FirstOrDefaultAsync(m => m.IdEstu == id);
            if (estudianteCarrera == null)
            {
                return NotFound();
            }

            return View(estudianteCarrera);
        }

        // POST: EstudianteCarreras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.EstudianteCarreras == null)
            {
                return Problem("Entity set 'AC_ScoreContext.EstudianteCarreras'  is null.");
            }
            var estudianteCarrera = await _context.EstudianteCarreras.FindAsync(id);
            if (estudianteCarrera != null)
            {
                _context.EstudianteCarreras.Remove(estudianteCarrera);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteCarreraExists(string id)
        {
          return _context.EstudianteCarreras.Any(e => e.IdEstu == id);
        }
    }
}
