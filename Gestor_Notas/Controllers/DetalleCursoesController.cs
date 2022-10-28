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
           
                var aC_ScoreContext = _context.DetalleCursos.Include(d => d.EstudianteNavigation).Include(d => d.IdCursoNavigation);
            return View(await aC_ScoreContext.ToListAsync());
            

        }

        // GET: DetalleCursoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if ((User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Administrador"))
            {
                if (id == null || _context.DetalleCursos == null)
            {
                return NotFound();
            }

            var detalleCurso = await _context.DetalleCursos
                .Include(d => d.EstudianteNavigation)
                .Include(d => d.IdCursoNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleCurso == id);
            if (detalleCurso == null)
            {
                return NotFound();
            }

            return View(detalleCurso);
            }
            else
            {
                return RedirectToAction("Index", "Error", new { data = "Error de acceso!!", data2 = "Usted no cuenta con los permisos necesario" });

            }
        }

        // GET: DetalleCursoes/Create
        public IActionResult Create()
        {

            if ((User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Administrador"))
            {
                var usuario = _context.Estudiantes.Select(a => new { IdUsuario = a.IdUsuario, Nombre = a.PrimerNombre + " " + a.SegundoNombre + " " + a.TercerNombre + " " + a.PrimerApellido + " " + a.SegundoApellido });

                ViewData["Estudiante"] = new SelectList(usuario, "IdUsuario", "Nombre");
                ViewData["IdCurso"] = new SelectList(_context.Cursos, "IdCurso", "Curso1");
                return View();
            }
            else if ((User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Catedratico"))
            {
            var usuario = _context.Estudiantes.Select(a => new { IdUsuario = a.IdUsuario, Nombre = a.PrimerNombre + " " + a.SegundoNombre + " " + a.TercerNombre + " " + a.PrimerApellido + " " + a.SegundoApellido });


                ViewData["Estudiante"] = new SelectList(usuario, "IdUsuario", "Nombre");
                ViewData["IdCurso"] = new SelectList(_context.Cursos, "IdCurso", "Curso1");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Error", new { data = "Error de acceso!!", data2 = "Usted no cuenta con los permisos necesario" });

            }
        }

        // POST: DetalleCursoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalleCurso,IdCurso,Estudiante,PrimerParcial,SegundoParcial,Actividades,ProyectoFinal,Extraordinario,Estado,FechaIngresoNota,FechaFinalizacion,NumeroActa,Año")] DetalleCurso detalleCurso)
        {
           
            //if (ModelState.IsValid)
            //{
                _context.Add(detalleCurso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            var usuario = _context.Estudiantes.Select(a => new { IdUsuario = a.IdUsuario, Nombre = a.PrimerNombre + " " + a.SegundoNombre + " " + a.TercerNombre + " " + a.PrimerApellido + " " + a.SegundoApellido });
            ViewData["Estudiante"] = new SelectList(usuario, "IdUsuario", "Nombre", detalleCurso.Estudiante);
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "IdCurso", "Curso1", detalleCurso.IdCurso);
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
            ViewData["Estudiante"] = new SelectList(_context.Estudiantes, "IdUsuario", "IdUsuario", detalleCurso.Estudiante);
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "IdCurso", "IdCurso", detalleCurso.IdCurso);
            return View(detalleCurso);
        }

        // POST: DetalleCursoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdDetalleCurso,IdCurso,Estudiante,PrimerParcial,SegundoParcial,Actividades,ProyectoFinal,Extraordinario,Estado,FechaIngresoNota,FechaFinalizacion,NumeroActa,Año")] DetalleCurso detalleCurso)
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
            ViewData["Estudiante"] = new SelectList(_context.Estudiantes, "IdUsuario", "IdUsuario", detalleCurso.Estudiante);
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "IdCurso", "IdCurso", detalleCurso.IdCurso);
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
                .Include(d => d.EstudianteNavigation)
                .Include(d => d.IdCursoNavigation)
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
