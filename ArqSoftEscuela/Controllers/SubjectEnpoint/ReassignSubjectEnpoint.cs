using ArqSoftEscuela.Repository.IRepository;
using ArqSoftEscuela.Requests;
using ArqSoftEscuela.Responses;

namespace ArqSoftEscuela.Controllers.SubjectEnpoint
{
    public class ReassignSubjectEnpoint : Endpoint<ReassignSubjectRequest, CreateSubjectResponse>
    {
        private readonly AutoMapper.IMapper _mapper;
        private readonly ISubjectRespository _subjectRespository;
        public ReassignSubjectEnpoint(AutoMapper.IMapper mapper, ISubjectRespository subjectRespository)
        {
            _mapper = mapper;
            _subjectRespository = subjectRespository;
        }

        public override void Configure()
        {
            Post("/subject/reassign");
            AllowAnonymous();
        }

        public override async Task HandleAsync(ReassignSubjectRequest req, CancellationToken ct)
        {
            var subject = _subjectRespository.GetSubject(req.Id);
            if (subject == null)
            {
                SendErrorsAsync();
            }

            subject.TeacherId = req.NewTeacherId;

            if (_subjectRespository.UpdateSubject(subject))
            {
                var locationUri = $"api/teacher/{subject.Id}";


                await SendAsync(new()
                {
                    uri = locationUri,
                    Subject = subject
                });
            }
            
        }
    }
}
