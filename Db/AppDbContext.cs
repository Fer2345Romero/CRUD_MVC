using CRUD_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_MVC.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Alumno> Alumnos { get; set; }
    }
}
