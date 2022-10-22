using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestor_Notas.Models;
using System.Xml.Linq;
using System.Text.Json.Serialization;

namespace Gestor_Notas.Controllers
{
    public class CursoesController : Controller
    {
        private readonly AC_ScoreContext _context;

        public CursoesController(AC_ScoreContext context)
        {
            _context = context;
        }

        // GET: Cursoes
        public async Task<IActionResult> Index()
        {
          string  uuid = User.Claims.ElementAt(2).ToString().Split(":")[1].ToString().Replace(" ", "");
            var aC_ScoreContext = _context.Cursos.Include(c => c.IdCarreraNavigation).Include(c => c.IdPeriodicidadNavigation).Include(c => c.IdUsuarioNavigation);


            if ((User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Student")){
                var xs = _context.Estudiantes.Where(x => x.IdUsuario == uuid).Include(x => x.EstudianteCarreras).First();
               
                aC_ScoreContext = _context.Cursos.Where(x => x.IdCarrera == xs.EstudianteCarreras.First().IdCarrera).Include(c => c.IdCarreraNavigation).Include(c => c.IdPeriodicidadNavigation).Include(c => c.IdUsuarioNavigation);
                return View(await aC_ScoreContext.ToListAsync());
            }
            else if(!(User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Administrador"))
            {
                var porf = _context.Usuarios.Where(x => x.IdUsuario == uuid).First();

                aC_ScoreContext = _context.Cursos.Where(x => x.IdUsuario == porf.IdUsuario).Include(c => c.IdCarreraNavigation).Include(c => c.IdPeriodicidadNavigation).Include(c => c.IdUsuarioNavigation);

                return View(await aC_ScoreContext.ToListAsync());
            }

            return View(await aC_ScoreContext.ToListAsync());
        }

        // GET: Cursoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos
                .Include(c => c.IdCarreraNavigation)
                .Include(c => c.IdPeriodicidadNavigation)
                .Include(c => c.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdCurso == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // GET: Cursoes/Create
        public IActionResult Create()
        {
            var usuario = _context.Usuarios.Select(a => new { IdUsuario = a.IdUsuario, Nombre = a.PrimerNombre + " " + a.SegundoNombre + " " + a.TercerNombre + " " + a.PrimerApellido + " " + a.SegundoApellido });

            ViewData["IdCarrera"] = new SelectList(_context.Carreras, "IdCarrera", "Carrera1");
            ViewData["IdPeriodicidad"] = new SelectList(_context.Periodicidads, "IdPeriodicidad", "Nombre");
            ViewData["IdUsuario"] = new SelectList(usuario, "IdUsuario", "Nombre");
            return View();
        }

        // POST: Cursoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCurso,Curso1,IdCarrera,IdUsuario,IdPeriodicidad")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCarrera"] = new SelectList(_context.Carreras, "IdCarrera", "IdCarrera", curso.IdCarrera);
            ViewData["IdPeriodicidad"] = new SelectList(_context.Periodicidads, "IdPeriodicidad", "IdPeriodicidad", curso.IdPeriodicidad);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", curso.IdUsuario);
            return View(curso);
        }

        // GET: Cursoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            var usuario = _context.Usuarios.Select(a => new { IdUsuario = a.IdUsuario, Nombre = a.PrimerNombre + " " + a.SegundoNombre + " " + a.TercerNombre + " " + a.PrimerApellido + " " + a.SegundoApellido });

            ViewData["IdCarrera"] = new SelectList(_context.Carreras, "IdCarrera", "Carrera1", curso.IdCarrera);
            ViewData["IdPeriodicidad"] = new SelectList(_context.Periodicidads, "IdPeriodicidad", "Nombre", curso.IdPeriodicidad);
            ViewData["IdUsuario"] = new SelectList(usuario, "IdUsuario", "Nombre", curso.IdUsuario);
            return View(curso);
        }

        // POST: Cursoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdCurso,Curso1,IdCarrera,IdUsuario,IdPeriodicidad")] Curso curso)
        {
            if (id != curso.IdCurso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoExists(curso.IdCurso))
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
            ViewData["IdCarrera"] = new SelectList(_context.Carreras, "IdCarrera", "IdCarrera", curso.IdCarrera);
            ViewData["IdPeriodicidad"] = new SelectList(_context.Periodicidads, "IdPeriodicidad", "IdPeriodicidad", curso.IdPeriodicidad);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", curso.IdUsuario);
            return View(curso);
        }

        // GET: Cursoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos
                .Include(c => c.IdCarreraNavigation)
                .Include(c => c.IdPeriodicidadNavigation)
                .Include(c => c.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdCurso == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // POST: Cursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                if (_context.Cursos == null)
                {
                    return Problem("Entity set 'AC_ScoreContext.Cursos'  is null.");
                }
                var curso = await _context.Cursos.FindAsync(id);
                if (curso != null)
                {
                    _context.Cursos.Remove(curso);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Index", "Error", new { data = "Error al eliminar Curso!!", data2 = "Este campo esta siendo utilizado" });

            }
        }

        private bool CursoExists(string id)
        {
          return _context.Cursos.Any(e => e.IdCurso == id);
        }
    }
}
