using System;
using System.Collections.Generic;

namespace Gestor_Notas.Models
{
    public partial class Sede
    {
        public Sede()
        {
            Carreras = new HashSet<Carrera>();
        }

        public string IdSede { get; set; } = null!;
        public string? Sede1 { get; set; }

        public virtual ICollection<Carrera> Carreras { get; set; }
    }
}
