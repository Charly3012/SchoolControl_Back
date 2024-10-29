using ArqSoftEscuela.Models;
using ArqSoftEscuela.Models.DTOs;
using ArqSoftEscuela.Requests;
using ArqSoftEscuela.Responses;
using AutoMapper;

namespace ArqSoftEscuela.Mapper
{
    public class EscuelaMapper : Profile
    {
        public EscuelaMapper() {

            CreateMap<Teacher, CreateTeacherRequest>().ReverseMap();       
            CreateMap<Teacher, GetTeacherResponse>().ReverseMap();
            CreateMap<Teacher, TeacherDTO>().ReverseMap();
            CreateMap<Teacher, TeacherSubjectDTO>().ReverseMap();

            CreateMap<Subject, GetSubjectResponse>().ReverseMap();
            CreateMap<Subject, SubjectDTO>().ReverseMap();
            CreateMap<Subject, CreateSubjectRequest>().ReverseMap();
            CreateMap<Subject, GetTeacherSubjectResponse>().ReverseMap();
        }
    }
}
