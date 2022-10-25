using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Gestor_Notas.Models
{
    public partial class Periodicidad
    {
        public Periodicidad()
        {
            Cursos = new HashSet<Curso>();
        }

        public string? IdPeriodicidad { get; set; } = null!;
        public string? Nombre { get; set; }
        [Display(Name = "Nombre de Sede:")]
        [Required(ErrorMessage = "Este campo debe ser llenado:")]
        public string? Descripcion { get; set; }
        [Display(Name = "Descripción:")]
        [Required(ErrorMessage = "Este campo debe ser llenado:")]

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
