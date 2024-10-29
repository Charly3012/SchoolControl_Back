using ArqSoftEscuela.Repository.IRepository;

namespace ArqSoftEscuela.Controllers.TeacherEP
{
    public class DeleteTeacherEnpoint : EndpointWithoutRequest
    {

        private readonly AutoMapper.IMapper _mapper;
        private readonly ITeacherRepository _teacherRepository;
        public DeleteTeacherEnpoint(AutoMapper.IMapper mapper, ITeacherRepository teacherRepository)
        {
            _mapper = mapper;
            _teacherRepository = teacherRepository;
        }

        public override void Configure()
        {
            Delete("/teacher/{id}");
            AllowAnonymous();
        }


        public override async Task HandleAsync(CancellationToken ct)
        {
            int id = Route<int>("id");
            if (!_teacherRepository.TeacherExist(id))
            {
                SendNotFoundAsync();
            }

            var teacher = _teacherRepository.GetTeacher(id);
            if (!_teacherRepository.DeleteTeacher(teacher))
            {
                SendErrorsAsync();
            }

            SendNoContentAsync();
        }
    }
}
