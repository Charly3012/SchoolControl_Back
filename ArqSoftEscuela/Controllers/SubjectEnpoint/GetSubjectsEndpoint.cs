using ArqSoftEscuela.Models.DTOs;
using ArqSoftEscuela.Repository.IRepository;
using ArqSoftEscuela.Responses;

namespace ArqSoftEscuela.Controllers.SubjectEnpoint
{
    public class GetSubjectsEndpoint : EndpointWithoutRequest<GetSubjectsResponse>
    {
        private readonly AutoMapper.IMapper _mapper;
        private readonly ISubjectRespository _subjectRespository;
        public GetSubjectsEndpoint(AutoMapper.IMapper mapper, ISubjectRespository subjectRespository)
        {
            _mapper = mapper;
            _subjectRespository = subjectRespository;
        }

        public override void Configure()
        {
            Get("/subject/");
            AllowAnonymous();
        }


        public override async Task HandleAsync(CancellationToken ct)
        {
            var list = _subjectRespository.GetSubjectsWithDetails();
            List<SubjectDTO> subjects = new List<SubjectDTO>();


            foreach (var subject in list)
            {
                var newSubject = _mapper.Map<SubjectDTO>(subject);
                subjects.Add(newSubject);
            }
            await SendAsync(new()
            {
                Subjects = subjects
            });

        }
    }
}
