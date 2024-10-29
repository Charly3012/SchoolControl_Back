using ArqSoftEscuela.Data;
using ArqSoftEscuela.Models;
using ArqSoftEscuela.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ArqSoftEscuela.Repository
{
    public class SubjectRepository : ISubjectRespository
    {
        private readonly ApplicationDBContext _db;
        public SubjectRepository(ApplicationDBContext db)
        {
            _db = db;
        }


        public bool CreateSubject(Subject subject)
        {
            _db.Subjects.Add(subject);
            return Save();
        }

        public bool DeleteSubject(Subject subject)
        {
            _db.Subjects.Remove(subject);
            return Save();
        }

        public Subject GetSubject(int id)
        {
            return _db.Subjects.FirstOrDefault(s => s.Id == id);
        }

        public ICollection<Subject> GetSubjects()
        {
            return _db.Subjects.OrderBy(s => s.Name).ToList();
        }

        public ICollection<Subject> GetSubjectsWithDetails()
        {
            return _db.Subjects
                .Include(t => t.Teacher) // Carga ansiosa de las asignaturas
                .OrderBy(t => t.Name)
                .ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;


        }


        public bool SubjectExist(int id)
        {
            if (id == 0)
            {
                return false;
            }

            return _db.Subjects.Any(t => t.Id == id);
        }

        public bool SubjectExist(string name)
        {
            if (name == null)
            {
                return false;
            }

            return _db.Teachers.Any(t => t.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        public bool UpdateSubject(Subject subject)
        {
            var currentSubject = _db.Subjects.Find(subject.Id);
            if (currentSubject != null)
            {
                _db.Entry(currentSubject).CurrentValues.SetValues(subject);
            }
            else
            {
                _db.Subjects.Update(subject);
            }

            return Save();
        }
    }
}
