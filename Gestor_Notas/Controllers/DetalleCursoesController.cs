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

    public class DetalleCursoesController : Controller
    {
        private readonly AC_ScoreContext _context;

        public DetalleCursoesController(AC_ScoreContext context)
        {
            _context = context;
        }

        // GET: DetalleCursoes
        public async Task<IActionResult> Index()
        {
            var aC_ScoreContext = _context.DetalleCursos.Include(d => d.IdCursoNavigation).Include(d => d.IdUsuarioNavigation);
            return View(await aC_ScoreContext.ToListAsync());
        }

        // GET: DetalleCursoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DetalleCursos == null)
            {
                return NotFound();
            }

            var detalleCurso = await _context.DetalleCursos
                .Include(d => d.IdCursoNavigation)
                .Include(d => d.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleCurso == id);
            if (detalleCurso == null)
            {
                return NotFound();
            }

            return View(detalleCurso);
        }

        // GET: DetalleCursoes/Create
        public IActionResult Create()
        {
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "IdCurso", "IdCurso");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: DetalleCursoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalleCurso,IdCurso,IdUsuario,PrimerParcial,SegundoParcial,Actividades,ProyectoFinal,Extraordinario,Estado,FechaIngresoNota,FechaFinalizacion,NumeroActa,Año")] DetalleCurso detalleCurso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleCurso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "IdCurso", "IdCurso", detalleCurso.IdCurso);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", detalleCurso.IdUsuario);
            return View(detalleCurso);
        }

        // GET: DetalleCursoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DetalleCursos == null)
            {
                return NotFound();
            }

            var detalleCurso = await _context.DetalleCursos.FindAsync(id);
            if (detalleCurso == null)
            {
                return NotFound();
            }
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "IdCurso", "IdCurso", detalleCurso.IdCurso);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", detalleCurso.IdUsuario);
            return View(detalleCurso);
        }

        // POST: DetalleCursoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdDetalleCurso,IdCurso,IdUsuario,PrimerParcial,SegundoParcial,Actividades,ProyectoFinal,Extraordinario,Estado,FechaIngresoNota,FechaFinalizacion,NumeroActa,Año")] DetalleCurso detalleCurso)
        {
            if (id != detalleCurso.IdDetalleCurso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleCurso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleCursoExists(detalleCurso.IdDetalleCurso))
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
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "IdCurso", "IdCurso", detalleCurso.IdCurso);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", detalleCurso.IdUsuario);
            return View(detalleCurso);
        }

        // GET: DetalleCursoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DetalleCursos == null)
            {
                return NotFound();
            }

            var detalleCurso = await _context.DetalleCursos
                .Include(d => d.IdCursoNavigation)
                .Include(d => d.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleCurso == id);
            if (detalleCurso == null)
            {
                return NotFound();
            }

            return View(detalleCurso);
        }

        // POST: DetalleCursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DetalleCursos == null)
            {
                return Problem("Entity set 'AC_ScoreContext.DetalleCursos'  is null.");
            }
            var detalleCurso = await _context.DetalleCursos.FindAsync(id);
            if (detalleCurso != null)
            {
                _context.DetalleCursos.Remove(detalleCurso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleCursoExists(string id)
        {
          return _context.DetalleCursos.Any(e => e.IdDetalleCurso == id);
        }
    }
}
