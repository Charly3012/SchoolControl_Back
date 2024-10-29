using System.ComponentModel.DataAnnotations;

namespace ArqSoftEscuela.Responses
{
    public class GetTeacherSubjectResponse
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Code { get; set; }
        
        public int Credits { get; set; }
    }
}
