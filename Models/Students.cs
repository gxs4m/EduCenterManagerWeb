using System.ComponentModel.DataAnnotations;

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
        public int CoursesId { get; set; } //Llave foranea
        public Courses Courses { get; set; } //Propiedad de navegación
        public ICollection<Ratings>? Ratings { get; set; } = default!; // Propiedad de navegación Calificaciones

    }
}
