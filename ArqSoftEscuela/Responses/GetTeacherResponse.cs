using ArqSoftEscuela.Models;
using System.ComponentModel.DataAnnotations;

namespace ArqSoftEscuela.Responses
{
    public class GetTeacherResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public List<GetTeacherSubjectResponse> Subjects { get; set; }


    }
}
