using ArqSoftEscuela.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArqSoftEscuela.Requests
{
    public class CreateSubjectRequest
    {
        
        public string Name { get; set; }

        public string Code { get; set; }

        public int Credits { get; set; }


        public int TeacherId { get; set; }    // Clave foránea que apunta al maestro

    }
}
