using CRUD_MVC.Db;
using CRUD_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public IActionResult Create()
        {
            Alumnos alumno = new();
            return View(alumno);
        }

        [HttpPost]

        public IActionResult Create(Alumnos model)
        {
            ModelState.Remove("NombreCompleto");
            if (ModelState.IsValid)
            {
                _dbConnetion.Alumnos.Add(model);
                _dbConnetion.SaveChanges();
                return RedirectToAction("Index");
            }
            //Retorna a unas accion especifica en el controlador
            return View(model);
        }
    }
}
