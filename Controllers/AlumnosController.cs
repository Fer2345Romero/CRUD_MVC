using CRUD_MVC.Db;
using CRUD_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_MVC.Controllers
{
    public class AlumnosController : Controller
    {
        private readonly AppDbContext _dbConnetion;
        public AlumnosController(AppDbContext appDb)
        {
            _dbConnetion = appDb;
        }

        public IActionResult Index()
        {
            List<Alumnos> alumnos = _dbConnetion.Alumnos.ToList();
            return View(alumnos);
        }
    }
}
