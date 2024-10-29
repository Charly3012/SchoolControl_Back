using ArqSoftEscuela.Repository.IRepository;
using ArqSoftEscuela.Models;
using ArqSoftEscuela.Requests;
using AutoMapper;
using System.Net.NetworkInformation;
using ArqSoftEscuela.Responses;


namespace ArqSoftEscuela.Controllers.TeacherEP
{
    public class CreateTeacher : Endpoint<CreateTeacherRequest, CreateTeacherResponse>
    {
        private readonly AutoMapper.IMapper _mapper;
        private readonly ITeacherRepository _teacherRepository;
        public CreateTeacher(AutoMapper.IMapper mapper, ITeacherRepository teacherRepository)
        {
            _mapper = mapper;
            _teacherRepository = teacherRepository;
        }

        public override void Configure()
        {
            Post("/teacher");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateTeacherRequest req, CancellationToken ct)
        {
            var teacher = _mapper.Map<Teacher>(req);

            var created = await Task.Run(() => _teacherRepository.CreateTeacher(teacher), ct);

            if (!created)
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            var locationUri = $"api/teacher/{teacher.Id}";
        

            await SendAsync(new()
            {
                Uri = locationUri,
                Teacher = teacher
            });


        }
    }
}



