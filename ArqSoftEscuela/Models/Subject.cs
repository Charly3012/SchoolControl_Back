using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArqSoftEscuela.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        [Required]  // Campo obligatorio
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]  // Campo obligatorio
        [MaxLength(100)]
        public string Code { get; set; }
        [Required]  // Campo obligatorio
        [Range(1, 10)]
        public int Credits { get; set; }


        // Relación uno a muchos: Cada asignatura tiene un único maestro
        [Required]
        public int TeacherId { get; set; }    // Clave foránea que apunta al maestro
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }     // Referencia al maestro que imparte la asignatura

    }
}
