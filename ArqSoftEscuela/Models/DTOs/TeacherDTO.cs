using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ArqSoftEscuela.Responses;

namespace ArqSoftEscuela.Models.DTOs
{
    public class TeacherDTO
    {
        
        public int Id { get; set; }
       
        public string Name { get; set; }
       
        public string Email { get; set; }

        public List<GetTeacherSubjectResponse> Subjects { get; set; }

    }
}
