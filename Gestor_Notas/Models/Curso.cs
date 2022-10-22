using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Gestor_Notas.Models
{
    public partial class Curso
    {
        public Curso()
        {
            DetalleCursos = new HashSet<DetalleCurso>();
        }

        public string? IdCurso { get; set; } = null!;
        [Display(Name = "Curso:")]
        [Required(ErrorMessage = "Porfavor Ingrese un Curso:")]
        public string? Curso1 { get; set; }
        [Display(Name = "Carrera:")]
        
        public string? IdCarrera { get; set; }
        [Display(Name = "Usuario:")]
        public string? IdUsuario { get; set; }
        [Display(Name = "Periodicidad:")]
        public string? IdPeriodicidad { get; set; }
        [Display(Name = "Carrera:")]
        public virtual Carrera? IdCarreraNavigation { get; set; }
        [Display(Name = "Periodicidad:")]
        public virtual Periodicidad? IdPeriodicidadNavigation { get; set; }
        [Display(Name = "Usuario:")]
        public virtual Usuario? IdUsuarioNavigation { get; set; }
        public virtual ICollection<DetalleCurso> DetalleCursos { get; set; }
    }
}
