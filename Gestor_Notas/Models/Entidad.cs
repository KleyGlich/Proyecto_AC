using System;
using System.Collections.Generic;

namespace Gestor_Notas.Models
{
    public partial class Entidad
    {
        public Entidad()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public string? IdRol { get; set; } = null!;
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
