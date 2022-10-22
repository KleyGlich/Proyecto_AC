using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

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
        [Display(Name = "Primer Nombre:")]
        public string? PrimerNombre { get; set; }
        [Display(Name = "Segundo Nombre:")]
        public string? SegundoNombre { get; set; }
        [Display(Name = "Tercer Nombre:")]
        public string? TercerNombre { get; set; }
        [Display(Name = "Primer Apellido:")]
        public string? PrimerApellido { get; set; }
        [Display(Name = "Segundo Apellido:")]
        public string? SegundoApellido { get; set; }
        [Display(Name = "No. de Identificación:")]
        public long? NoIdentificacion { get; set; }
        [Display(Name = "Usuario:")]
        public string? Usuario { get; set; }
        [Display(Name = "Contraseña:")]
        public string? Contraseña { get; set; }
        [Display(Name = "Inscripción:")]
        [DataType(DataType.Date)]
        public DateTime? Inscripcion { get; set; }
        [Display(Name = "Rol:")]
        public string? IdRol { get; set; }
        [Display(Name = "Cursos:")]
        public virtual ICollection<DetalleCurso> DetalleCursos { get; set; }
        [Display(Name = "Carrera:")]
        public virtual ICollection<EstudianteCarrera> EstudianteCarreras { get; set; }
    }
}
