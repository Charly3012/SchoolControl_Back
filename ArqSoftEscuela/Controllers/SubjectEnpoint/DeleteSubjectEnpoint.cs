using ArqSoftEscuela.Repository.IRepository;

namespace ArqSoftEscuela.Controllers.SubjectEnpoint
{
    public class DeleteSubjectEnpoint : EndpointWithoutRequest
    {
        private readonly AutoMapper.IMapper _mapper;
        private readonly ISubjectRespository _subjectRespository;
        public DeleteSubjectEnpoint(AutoMapper.IMapper mapper, ISubjectRespository subjectRespository)
        {
            _mapper = mapper;
            _subjectRespository = subjectRespository;
        }

        public override void Configure()
        {
            Delete("/subject/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            int id = Route<int>("id");
            if (!_subjectRespository.SubjectExist(id))
            {
                SendNotFoundAsync();
            }

            var teacher = _subjectRespository.GetSubject(id);
            if (!_subjectRespository.DeleteSubject(teacher))
            {
                SendErrorsAsync();
            }

            SendNoContentAsync();
        }
    }
}
