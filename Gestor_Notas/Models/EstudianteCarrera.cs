using System;
using System.Collections.Generic;

namespace Gestor_Notas.Models
{
    public partial class EstudianteCarrera
    {
        public string? IdEstu { get; set; } = null!;
        public string? IdCarrera { get; set; }
        public string? Estudiante { get; set; }

        public virtual Estudiante? EstudianteNavigation { get; set; }
        public virtual Carrera? IdCarreraNavigation { get; set; }
    }
}
