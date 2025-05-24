using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduCenterManagerWeb.Models
{
    public class Schedules
    {
        [Key]
        public int IdHorario { get; set; }
        [ForeignKey("CoursesId")]
        public int CoursesId { get; set; } // Llave foranea
        public Courses? Courses { get; set; } // Propiedad de navegación Cursos
        public string? DiaSemana { get; set; }
        public string? HoraInicio { get; set; }
        public string? HoraFin { get; set; }
    }
}
