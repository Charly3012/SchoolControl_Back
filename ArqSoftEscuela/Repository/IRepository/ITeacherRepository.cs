using ArqSoftEscuela.Models;

namespace ArqSoftEscuela.Repository.IRepository
{
    public interface ITeacherRepository
    {
        ICollection<Teacher> GetTeachers();

        Teacher GetTeacher(int teacherId);

        ICollection<Teacher> GetTeachersWithSubjects();

        bool TeacherExist(int teacherId);

        bool TeacherExist(string name);

        bool CreateTeacher(Teacher teacher);

        bool UpdateTeacher(Teacher teacher);

        bool DeleteTeacher(Teacher teacher);

        bool Save();
    }
}



