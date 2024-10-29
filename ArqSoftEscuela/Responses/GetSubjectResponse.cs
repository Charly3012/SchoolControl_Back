using ArqSoftEscuela.Models;
using ArqSoftEscuela.Models.DTOs;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArqSoftEscuela.Responses
{
    public class GetSubjectResponse
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Code { get; set; }
        
        public int Credits { get; set; }


        
        public int TeacherId { get; set; }    
        
        public TeacherDTO Teacher { get; set; }     
    }
}
