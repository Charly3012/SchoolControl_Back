using ArqSoftEscuela.Models;
using ArqSoftEscuela.Repository.IRepository;
using ArqSoftEscuela.Responses;

namespace ArqSoftEscuela.Controllers.TeacherEP
{
    public class GetTeacher : EndpointWithoutRequest<GetTeacherResponse>
    {

        private readonly AutoMapper.IMapper _mapper;
        private readonly ITeacherRepository _teacherRepository;
        public GetTeacher(AutoMapper.IMapper mapper, ITeacherRepository teacherRepository)
        {
            _mapper = mapper;
            _teacherRepository = teacherRepository;
        }


        public override void Configure()
        {
            Get("/teacher/{id}");
            AllowAnonymous();
        }


        public override async Task HandleAsync(CancellationToken ct)
        {
            int id = Route<int>("id");
            var teacher = _teacherRepository.GetTeacher(id);

            if (teacher == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            var teacherResponse = _mapper.Map<GetTeacherResponse>(teacher);

            await SendAsync(teacherResponse);
        }

    }
}
