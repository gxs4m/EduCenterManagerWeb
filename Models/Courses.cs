using System.ComponentModel.DataAnnotations.Schema;

namespace EduCenterManagerWeb.Models
{
    public class Courses
    {
        public int Id { get; set; } // Primary Key
        public string? Name { get; set; } 
        public string? Description { get; set; }
        [ForeignKey("TeachersId")]
        public int TeachersId { get; set; } // Llave Foranea
        public Teachers? Teachers { get; set; } // Propiedad de navegación Profesores
        public ICollection<Students>? Students { get; set; } // Propiedad de navegación Estudiantes
        public ICollection<Schedules>? Schedules { get; set; } // Propiedad de navegación Horarios
        public ICollection<Ratings>? Ratings { get; set; } // Propiedad de navegación Calificaciones

    }
}
