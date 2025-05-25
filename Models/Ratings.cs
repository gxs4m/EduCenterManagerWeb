using System.ComponentModel.DataAnnotations;

namespace EduCenterManagerWeb.Models
{
    public class Ratings
    {
        [Key]
        public int IdCalificacion { get; set; } // Primary Key
        public int StudentsId { get; set; } // Llave foranea
        public Students? Students { get; set; } // Propiedad de navegación Estudiantes
        public int CoursesId { get; set; } // Llave foranea
        public Courses? Courses { get; set; } // Propiedad de navegación Cursos
        public int Nota { get; set; } 
        public string? Fecha { get; set; } 
    }
}
