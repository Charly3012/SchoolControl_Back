using ArqSoftEscuela.Data;
using ArqSoftEscuela.Models;
using ArqSoftEscuela.Repository.IRepository;
using System.ComponentModel.Design;
using Microsoft.EntityFrameworkCore;

namespace ArqSoftEscuela.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDBContext _db;

        public TeacherRepository(ApplicationDBContext db)
        {
            _db = db;   
        }



        public bool CreateTeacher(Teacher teacher)
        {
            _db.Teachers.Add(teacher);
            return Save();
        }

        public bool DeleteTeacher(Teacher teacher)
        {
            _db.Teachers.Remove(teacher);
            return Save();
        }

        public Teacher GetTeacher(int teacherId)
        {
            return _db.Teachers.Include(t => t.Subjects).FirstOrDefault(t => t.Id == teacherId);
                
        }


        // Nuevo método para obtener maestros con sus asignaturas
        public ICollection<Teacher> GetTeachersWithSubjects()
        {
            return _db.Teachers
                .Include(t => t.Subjects) // Carga ansiosa de las asignaturas
                .OrderBy(t => t.Name)
                .ToList();
        }

        public ICollection<Teacher> GetTeachers()
        {
            return _db.Teachers.OrderBy(t => t.Name).ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool TeacherExist(int teacherId)
        {
            if (teacherId == 0)
            {
                return false;
            }

            return _db.Teachers.Any(t => t.Id == teacherId);
        }

        public bool TeacherExist(string email)
        {
            if(email  == null)
            {
                return false;
            }

            return _db.Teachers.Any(t => t.Email.ToLower().Trim() == email.ToLower().Trim());
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            var currenTeacher = _db.Teachers.Find(teacher.Id);
            if(currenTeacher != null)
            {
                _db.Entry(currenTeacher).CurrentValues.SetValues(teacher);
            }
            else
            {
                _db.Teachers.Update(teacher);
            }

            return Save();
        }
    }
}
