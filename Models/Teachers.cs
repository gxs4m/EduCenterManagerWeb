using System.ComponentModel.DataAnnotations;

namespace EduCenterManagerWeb.Models
{
    public class Teachers
    {
        [Key]
        public int IdProfesor { get; set; } // Primary Key
        public string? Nombre { get; set; } 
        public string? Apellido { get; set; }
        public string? Especialidad { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }

    }
}
