using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Gestor_Notas.Models
{
    public partial class Entidad
    {
        public Entidad()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public string? IdRol { get; set; } = null!;
        [Display(Name = "Nombre:")]
        [Required(ErrorMessage = "Este dato debe ser especificado:")]
        public string? Nombre { get; set; }
        [Display(Name = "Descripción:")]
        [Required(ErrorMessage = "Este dato debe ser especificado:")]
        public string? Descripcion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
