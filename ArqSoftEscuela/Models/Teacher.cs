using System.ComponentModel.DataAnnotations;

namespace ArqSoftEscuela.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required] 
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]  
        [MaxLength(100)]
        public string Email { get; set; }


        public List<Subject> Subjects { get; set; }

    }
}
