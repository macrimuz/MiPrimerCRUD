using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiPrimerCRUD.Models
{
    [Table("Alumnos")]
    public class Alumno
    {
        [Key]
        public long Id { get; set; }

        public string Nombre { get; set; }
        
        public DateTime FechaInicio { get; set; }

        public bool Activo { get; set; }

        public virtual ICollection<Curso>? Cursos { get; set; }
        
        
    
    }
}
