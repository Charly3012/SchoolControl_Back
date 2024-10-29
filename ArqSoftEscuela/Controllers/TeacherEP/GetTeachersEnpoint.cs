using ArqSoftEscuela.Models;
using ArqSoftEscuela.Models.DTOs;
using ArqSoftEscuela.Repository.IRepository;
using ArqSoftEscuela.Responses;

namespace ArqSoftEscuela.Controllers.TeacherEP
{
    public class GetTeachersEnpoint : EndpointWithoutRequest<GetTeachersReponse>
    {

        private readonly AutoMapper.IMapper _mapper;
        private readonly ITeacherRepository _teacherRepository;
        public GetTeachersEnpoint(AutoMapper.IMapper mapper, ITeacherRepository teacherRepository)
        {
            _mapper = mapper;
            _teacherRepository = teacherRepository;
        }

        public override void Configure()
        {
            Get("/teacher/");
            AllowAnonymous();
        }


        public override async Task HandleAsync(CancellationToken ct)
        {
            
            List<TeacherDTO> list = new List<TeacherDTO>();

            var teacherList = _teacherRepository.GetTeachersWithSubjects();

            foreach (var teacher in teacherList)
            {
                var newTeacher = _mapper.Map<TeacherDTO>(teacher);
                list.Add(newTeacher);
            }

            await SendAsync(new()
            {
                Teachers = list
            });
        }
    }
}
