using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduCenterManagerWeb.Models
{
    public class Students
    {
        [Key]
        public int IdEstudiante { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? FechaNacimiento { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        [ForeignKey("CoursesId")]
        public int CoursesId { get; set; } //Llave foranea
        public Courses? Courses { get; set; } //Propiedad de navegación
        public ICollection<Ratings>? Ratings { get; set; } // Propiedad de navegación Calificaciones

    }
}
