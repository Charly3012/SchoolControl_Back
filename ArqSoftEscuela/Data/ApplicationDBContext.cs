using ArqSoftEscuela.Models;
using Microsoft.EntityFrameworkCore;

namespace ArqSoftEscuela.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        //Aquí pasamos todos los modelos que queremos en la base de datos 
        //Entidades

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
