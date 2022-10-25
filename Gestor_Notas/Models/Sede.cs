using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gestor_Notas.Models
{
    public partial class Sede
    {
        public Sede()
        {
            Carreras = new HashSet<Carrera>();
        }

        public string? IdSede { get; set; } = null!;
        [Display(Name = "Nombre de Sede :")]
        [Required(ErrorMessage = "Este campo debe ser llenado:")]
        public string? Sede1 { get; set; }

        public virtual ICollection<Carrera> Carreras { get; set; }
    }
}
