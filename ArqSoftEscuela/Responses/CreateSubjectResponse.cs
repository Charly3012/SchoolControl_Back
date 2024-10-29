using ArqSoftEscuela.Models;

namespace ArqSoftEscuela.Responses
{
    public class CreateSubjectResponse
    {
        public string uri {  get; set; }
        public Subject Subject { get; set; }
    }
}
