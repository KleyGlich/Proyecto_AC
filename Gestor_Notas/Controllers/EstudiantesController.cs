using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestor_Notas.Models;
using System.Text;
using System.Security.Cryptography;

namespace Gestor_Notas.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly AC_ScoreContext _context;

        public EstudiantesController(AC_ScoreContext context)
        {
            _context = context;
        }

        // GET: Estudiantes
        public async Task<IActionResult> Index()
        {
            if (User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Administrador")
            {
                return View(await _context.Estudiantes.ToListAsync());
           
            }else if (User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Catedratico")
            {
                return View(await _context.Estudiantes.ToListAsync());
            }
            else
            {
                return RedirectToAction("Index", "Error", new { data = "Error de acceso!!", data2 = "Usted no cuenta con los permisos necesario" });

            }
        }

        // GET: Estudiantes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Administrador")
            {
                if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
            
            }
            else
            {
                return RedirectToAction("Index", "Error", new { data = "Error de acceso!!", data2 = "Usted no cuenta con los permisos necesario" });

            }
        }

        // GET: Estudiantes/Create
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
        // POST: Estudiantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,PrimerNombre,SegundoNombre,TercerNombre,PrimerApellido,SegundoApellido,NoIdentificacion,Usuario,Contraseña,IdRol,Inscripcion")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                estudiante.IdRol = "Student";
                string pass = GetSHA256(estudiante.Contraseña).ToUpper();
                estudiante.Contraseña = pass;
                _context.Add(estudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Administrador")
            {

                if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            return View(estudiante);
            }
            else
            {
                return RedirectToAction("Index", "Error", new { data = "Error de acceso!!", data2 = "Usted no cuenta con los permisos necesario" });

            }
        }

        // POST: Estudiantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdUsuario,PrimerNombre,SegundoNombre,TercerNombre,PrimerApellido,SegundoApellido,NoIdentificacion,Usuario,Contraseña,IdRol,Inscripcion")] Estudiante estudiante)
        {
            if (id != estudiante.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string pass = GetSHA256(estudiante.Contraseña).ToUpper();
                    estudiante.Contraseña = pass;
                    estudiante.IdRol = "Student";
                    _context.Update(estudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteExists(estudiante.IdUsuario))
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
            return View(estudiante);
        }

        // GET: Estudiantes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (User.Claims.ElementAt(1).ToString().Split(':')[1].ToString().Replace(" ", "") == "Administrador")
            {
                if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
            }
            else
            {
                return RedirectToAction("Index", "Error", new { data = "Error de acceso!!", data2 = "Usted no cuenta con los permisos necesario" });

            }
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                if (_context.Estudiantes == null)
                {
                    return Problem("Entity set 'AC_ScoreContext.Estudiantes'  is null.");
                }
                var estudiante = await _context.Estudiantes.FindAsync(id);
                if (estudiante != null)
                {
                    _context.Estudiantes.Remove(estudiante);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Index", "Error", new { data = "Error al eliminar Estudiante!!", data2 = "Este campo esta siendo utilizado" });

            }
        }
        private string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        private bool EstudianteExists(string id)
        {
          return _context.Estudiantes.Any(e => e.IdUsuario == id);
        }
    }
}
