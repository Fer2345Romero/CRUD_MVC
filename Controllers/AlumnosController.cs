using CRUD_MVC.Db;
using CRUD_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        [HttpGet]
        public IActionResult UpSert(int id)
        {
            if(id == 0)
            {
                //Registro nuevo
                Alumnos alumno = new();
                return View(alumno);
            }
            else
            {
                //Registro existente
                Alumnos alumno = _dbConnetion.Alumnos.FirstOrDefault(row => row.AlumnoId == id) ?? new();
                return View(alumno);

            }
           
        }

        [HttpPost]

        public IActionResult UpSert(Alumnos model)
        {
            //remover propiedad --No se esta ocupando 
            ModelState.Remove("NombreCompleto");
            if (model.AlumnoId == 0)
            {
                if (ModelState.IsValid)
                {
                    _dbConnetion.Alumnos.Add(model);
                    _dbConnetion.SaveChanges();
                    return RedirectToAction("Index");
                }       
            }
            else 
            {
                if(ModelState.IsValid)
                {
                    _dbConnetion.Alumnos.Update(model);
                    _dbConnetion.SaveChanges();
                    return RedirectToAction("Index");
                }
            }  
            //Retorna a unas accion especifica en el controlador
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Alumnos alumno = _dbConnetion.Alumnos.FirstOrDefault(row => row.AlumnoId == id)?? new();
            alumno.IsActive = false;
            _dbConnetion.Alumnos.Update(alumno);
            _dbConnetion.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
