using ArqSoftEscuela.Models;
using ArqSoftEscuela.Repository.IRepository;
using ArqSoftEscuela.Requests;
using ArqSoftEscuela.Responses;
using static FastEndpoints.Ep;

namespace ArqSoftEscuela.Controllers.SubjectEnpoint
{
    public class CreateSubjectEnpoint : Endpoint<CreateSubjectRequest, CreateSubjectResponse>
    {

        private readonly AutoMapper.IMapper _mapper;
        private readonly ISubjectRespository _subjectRespository;
        public CreateSubjectEnpoint(AutoMapper.IMapper mapper, ISubjectRespository subjectRespository)
        {
            _mapper = mapper;
            _subjectRespository = subjectRespository;
        }

        public override void Configure()
        {
            Post("/subject/");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateSubjectRequest req, CancellationToken ct)
        {
            var subject = _mapper.Map<Subject>(req);

            var created = await Task.Run(() => _subjectRespository.CreateSubject(subject), ct);

            if (!created)
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            var locationUri = $"api/teacher/{subject.Id}";


            await SendAsync(new()
            {
                uri = locationUri,
                Subject = subject
            });


        }
    }
}
