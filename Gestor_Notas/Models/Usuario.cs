using System;
using System.Collections.Generic;

namespace Gestor_Notas.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Cursos = new HashSet<Curso>();
        }

        public string? IdUsuario { get; set; } = null!;
        public string? PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? TercerNombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public long? NoIdentificacion { get; set; }
        public string? Profesion { get; set; }
        public string? Tipo { get; set; }
        public string? Usuario1 { get; set; }
        public string? Contraseña { get; set; }
        public string? IdRol { get; set; }

        public virtual Entidad? IdRolNavigation { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
