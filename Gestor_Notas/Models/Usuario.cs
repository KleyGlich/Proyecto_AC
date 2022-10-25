using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Gestor_Notas.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Cursos = new HashSet<Curso>();
        }

        public string? IdUsuario { get; set; } = null!;
        [Display(Name = "Primer Nombre:")]
        [Required(ErrorMessage = "Este campo debe ser llenado:")]
        public string? PrimerNombre { get; set; }
        [Display(Name = "Segundo Nombre:")]
        [Required(ErrorMessage = "Este campo debe ser llenado:")]
        public string? SegundoNombre { get; set; }
        [Display(Name = "Tercer Nombre:")]
        
        public string? TercerNombre { get; set; }
        [Display(Name = "Primer Apellido:")]
        [Required(ErrorMessage = "Este campo debe ser llenado:")]
        public string? PrimerApellido { get; set; }
        [Display(Name = "Segundo Apellido:")]
       
        public string? SegundoApellido { get; set; }
        [Display(Name = "No. Identificación:")]
        [Required(ErrorMessage = "Este campo debe ser llenado:")]
        public long? NoIdentificacion { get; set; }
        [Display(Name = "Profesión:")]
        [Required(ErrorMessage = "Este campo debe ser llenado:")]
        public string? Profesion { get; set; }
        [Display(Name = "Tipo:")]
        [Required(ErrorMessage = "Este campo debe ser llenado:")]
        public string? Tipo { get; set; }
        [Display(Name = "Usuario:")]
        [Required(ErrorMessage = "Este campo debe ser llenado:")]
        public string? Usuario1 { get; set; }
        [Display(Name = "Contraseña:")]
        [Required(ErrorMessage = "Este campo debe ser llenado:")]
        public string? Contraseña { get; set; }
        [Display(Name = "Rol:")]
        public string? IdRol { get; set; }

        [Display(Name = "Rol:")]
        public virtual Entidad? IdRolNavigation { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
