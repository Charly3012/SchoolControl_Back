using ArqSoftEscuela.Repository;
using ArqSoftEscuela.Repository.IRepository;
using ArqSoftEscuela.Responses;

namespace ArqSoftEscuela.Controllers.SubjectEnpoint
{
    public class GetSubject : EndpointWithoutRequest<GetSubjectResponse>
    {

        private readonly AutoMapper.IMapper _mapper;
        private readonly ISubjectRespository _subjectRespository;
        public GetSubject(AutoMapper.IMapper mapper, ISubjectRespository subjectRespository )
        {
            _mapper = mapper;
            _subjectRespository = subjectRespository;
        }

        public override void Configure()
        {
            Get("/subject/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            int id = Route<int>("id");
            
            var subject = _subjectRespository.GetSubject(id);

            if (subject == null)
            {
                SendNotFoundAsync(ct);
            }

            var subjectResponse = _mapper.Map<GetSubjectResponse>(subject);

            SendOkAsync(subjectResponse);
        }

    }
}
