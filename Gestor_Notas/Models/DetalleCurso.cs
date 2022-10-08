using System;
using System.Collections.Generic;

namespace Gestor_Notas.Models
{
    public partial class DetalleCurso
    {
        public string IdDetalleCurso { get; set; } = null!;
        public string IdCurso { get; set; } = null!;
        public string IdUsuario { get; set; } = null!;
        public int? PrimerParcial { get; set; }
        public int? SegundoParcial { get; set; }
        public int? Actividades { get; set; }
        public int? ProyectoFinal { get; set; }
        public int? Extraordinario { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaIngresoNota { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public int? NumeroActa { get; set; }
        public string? Año { get; set; }

        public virtual Curso IdCursoNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
