using ArqSoftEscuela.Models;

namespace ArqSoftEscuela.Repository.IRepository
{
    public interface ISubjectRespository
    {
        ICollection<Subject> GetSubjects();

        Subject GetSubject(int id);

        ICollection<Subject> GetSubjectsWithDetails();

        bool SubjectExist(int id);

        bool  SubjectExist(string name);

        bool CreateSubject(Subject subject);

        bool UpdateSubject(Subject subject);

        bool DeleteSubject(Subject subject);

        bool Save();
    }
}
