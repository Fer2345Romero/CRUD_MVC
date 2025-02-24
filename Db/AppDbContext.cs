using CRUD_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_MVC.Db
{
    //Esta es la clase que maneja la conexion con la BD
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //Las tablas o entidades que se van a representar en la BD
        public DbSet<Alumnos> Alumnos { get; set; }
    }
}
