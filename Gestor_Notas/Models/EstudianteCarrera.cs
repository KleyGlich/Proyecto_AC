using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Gestor_Notas.Models
{
    public partial class EstudianteCarrera
    {
        

        public string? IdEstu { get; set; } = null!;
        [Display(Name = "Carrera:")]
        public string? IdCarrera { get; set; }

        [Display(Name = "Estudiante:")]
        public string? Estudiante { get; set; }
        [Display(Name = "Estudiante:")]


        public virtual Estudiante? EstudianteNavigation { get; set; }
        [Display(Name = "Carrera:")]
        public virtual Carrera? IdCarreraNavigation { get; set; }
       
        

    }
}
