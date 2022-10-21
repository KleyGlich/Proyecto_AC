using System;
using System.Collections.Generic;

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
        public string? Carrera1 { get; set; }
        public string? IdSede { get; set; }

        public virtual Sede? IdSedeNavigation { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
        public virtual ICollection<EstudianteCarrera> EstudianteCarreras { get; set; }
    }
}
