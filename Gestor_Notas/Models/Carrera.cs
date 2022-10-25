using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Gestor_Notas.Models
{
    public partial class Carrera
    {
        public Carrera()
        {
            Cursos = new HashSet<Curso>();
            EstudianteCarreras = new HashSet<EstudianteCarrera>();
        }

        public string? IdCarrera { get; set; } = null!;
        [Display(Name = "Carrera:")]
        [Required(ErrorMessage = "Este dato debe ser especificado:")]
        public string? Carrera1 { get; set; }
        [Display(Name = "Sede:")]
  
        public string? IdSede { get; set; }

        [Display(Name = "Sede:")]
        [Required(ErrorMessage = "Este dato debe ser especificado:")]
        public virtual Sede? IdSedeNavigation { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
        public virtual ICollection<EstudianteCarrera> EstudianteCarreras { get; set; }
    }
}
