using ArqSoftEscuela.Models;
using ArqSoftEscuela.Models.DTOs;

namespace ArqSoftEscuela.Responses
{
    public class GetSubjectsResponse
    {
        public List<SubjectDTO> Subjects { get; set; }
    }
}
