using System;
using System.Collections.Generic;

namespace Gestor_Notas.Models
{
    public partial class Curso
    {
        public Curso()
        {
            DetalleCursos = new HashSet<DetalleCurso>();
        }

        public string? IdCurso { get; set; } = null!;
        public string? Curso1 { get; set; }
        public string? IdCarrera { get; set; }
        public string? IdUsuario { get; set; }
        public string? IdPeriodicidad { get; set; }

        public virtual Carrera? IdCarreraNavigation { get; set; }
        public virtual Periodicidad? IdPeriodicidadNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
        public virtual ICollection<DetalleCurso> DetalleCursos { get; set; }
    }
}
