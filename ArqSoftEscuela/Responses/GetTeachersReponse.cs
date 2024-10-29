using ArqSoftEscuela.Models.DTOs;

namespace ArqSoftEscuela.Responses
{
    public class GetTeachersReponse
    {
       public ICollection<TeacherDTO> Teachers { get; set; }
    }
}
