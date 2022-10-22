using Gestor_Notas.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_Notas.Controllers
{
    public class AccountController : Controller
    {

        private readonly AC_ScoreContext _context;

        public AccountController(AC_ScoreContext context)
        {
            _context = context;
        }


        [HttpGet("Login")]
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> validate(string usuario, string password)
        {
            List<Claim> claims = new List<Claim>();
            string pass = GetSHA256(password).ToUpper();
           
            var val = _context.Usuarios.Where(x => x.Usuario1 == usuario && pass == x.Contraseña).Join(_context.Entidads, x => x.IdRol , us => us.IdRol ,
                 (x, us) => new
                 {
                     PrimerNombre = x.PrimerNombre,
                     SegundoNombre = x.SegundoNombre,
                     Rol = us.Nombre,
                     ID = x.IdUsuario
                 }
                ).ToList();
            var val2 = new  List<Estudiante>();
            if (!val.Any())
            {
               
                val2 = (from a in _context.Estudiantes where usuario == a.Usuario && pass == a.Contraseña select a).ToList();
                if (val2.Any())
                {
                    // creamos un listado de peticion
                    claims.Add(new Claim("username", val2.First().PrimerNombre + " " + val2.First().SegundoNombre)); // guardamos el nombre de quien se logea
                    claims.Add(new Claim("Rol", val2.First().IdRol)); // guardamos el nombre de quien se logea
                    claims.Add(new Claim("ID", val2.First().IdUsuario)); // guardamos el nombre de quien se logea

                    claims.Add(new Claim(ClaimTypes.NameIdentifier, val2.First().PrimerNombre + " " + val2.First().SegundoNombre)); //guardamos el tipo de peticion 
                    var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme); // asignamos esa peticicon a un esquema de cookies
                    var claimprincipal = new ClaimsPrincipal(claimIdentity); // la volvemos peticion principal


                    await HttpContext.SignInAsync(claimprincipal); // cremos la cookie de autentificacion

                    return RedirectToAction("Index", "Home"); // redireccion a un pagina 
                }
                else
                {

                    return RedirectToAction("Index", "Error", new { data = "Error de Log in", data2 = "Credenciales Incorectas" });
                    // si el usuario no es valido envia un badrequest como respuesta


                }

            }
            else
            {
                if (val.Any())
                {
                    // creamos un listado de peticion
                    claims.Add(new Claim("username", val.First().PrimerNombre + " " + val.First().SegundoNombre)); // guardamos el nombre de quien se logea
                    claims.Add(new Claim("Rol", val.First().Rol)); // guardamos el nombre de quien se logea
                    claims.Add(new Claim("ID", val.First().ID)); // guardamos el nombre de quien se logea

                    claims.Add(new Claim(ClaimTypes.NameIdentifier, val.First().PrimerNombre + " " + val.First().SegundoNombre)); //guardamos el tipo de peticion 
                    var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme); // asignamos esa peticicon a un esquema de cookies
                    var claimprincipal = new ClaimsPrincipal(claimIdentity); // la volvemos peticion principal


                    await HttpContext.SignInAsync(claimprincipal); // cremos la cookie de autentificacion

                    return RedirectToAction("Index", "Home"); // redireccion a un pagina 
                }
                else
                {

                    return RedirectToAction("Index", "Error", new { data = "Error de Log in", data2 = "Credenciales incorrectas" });
                    // si el usuario no es valido envia un badrequest como respuesta


                }

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
        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync(
     CookieAuthenticationDefaults.AuthenticationScheme); //elimina la cookie creada 
            return RedirectToAction("Index", "Home"); // regresa a una pagina especifica 
        }
    }
}
