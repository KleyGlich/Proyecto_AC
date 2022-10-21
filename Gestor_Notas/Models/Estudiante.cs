using System;
using System.Collections.Generic;

namespace Gestor_Notas.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            DetalleCursos = new HashSet<DetalleCurso>();
            EstudianteCarreras = new HashSet<EstudianteCarrera>();
        }

        public string? IdUsuario { get; set; } = null!;
        public string? PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? TercerNombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public long? NoIdentificacion { get; set; }
        public string? Usuario { get; set; }
        public string? Contraseña { get; set; }
        public DateTime? Inscripcion { get; set; }
        public string? IdRol { get; set; }

        public virtual ICollection<DetalleCurso> DetalleCursos { get; set; }
        public virtual ICollection<EstudianteCarrera> EstudianteCarreras { get; set; }
    }
}
