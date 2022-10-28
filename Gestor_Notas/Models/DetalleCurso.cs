using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Gestor_Notas.Models
{
    public partial class DetalleCurso
    {
        public string? IdDetalleCurso { get; set; } = null!;
        [Display(Name = "Curso:")]
        public string IdCurso { get; set; } = null!;
        [Display(Name = "Estudiante:")]
        public string Estudiante { get; set; } = null!;
        [Display(Name = "Primer Parcial:")]
        [Required(ErrorMessage = "Este campo debe ser llenado")]
        public int? PrimerParcial { get; set; }
        [Display(Name = "Segundo Parcial:")]
        [Required(ErrorMessage = "Este campo debe ser llenado")]
        public int? SegundoParcial { get; set; }
        [Display(Name = "Actividades:")]
        [Required(ErrorMessage = "Este campo debe ser llenado")]
        public int? Actividades { get; set; }
        [Display(Name = "Proyecto Final:")]
        [Required(ErrorMessage = "Este campo debe ser llenado")]
        public int? ProyectoFinal { get; set; }
        [Display(Name = " Extraordinario:")]
        [Required(ErrorMessage = "Este campo debe ser llenado")]
        public int? Extraordinario { get; set; }
        [Display(Name = " Estado:")]
        public bool Estado { get; set; }
        [Display(Name = "Fecha de Ingreso de Notas:")]
        [DataType(DataType.Date)]
        public DateTime? FechaIngresoNota { get; set; }
        [Display(Name = "Fecha de Fin de Ingreso de Notas:")]
        [DataType(DataType.Date)]
        public DateTime? FechaFinalizacion { get; set; }
        [Display(Name = "Numero de Acta:")]
        [Required(ErrorMessage = "Este campo debe ser llenado")]
        public int? NumeroActa { get; set; }
        [Display(Name = "Año:")]
        [Required(ErrorMessage = "Este campo debe ser llenado")]
        public string? Año { get; set; }
        [Display(Name = "Estudiante:")]
        public virtual Estudiante EstudianteNavigation { get; set; } = null!;
        [Display(Name = "Curso:")]
        public virtual Curso IdCursoNavigation { get; set; } = null!;
    }
}
