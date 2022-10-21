using System;
using System.Collections.Generic;

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
        public string? Descripcion { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
