using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUD_MVC.Models;
using CRUD_MVC.Db;

namespace CRUD_MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    //Instancia de la clase appDbContext que es la representación en codigo de la BD
    private readonly AppDbContext appDbContext;

    //Constructore en el que se inicializa
    public HomeController(ILogger<HomeController> logger, AppDbContext _dbContext)
    {
        _logger = logger;
        appDbContext = _dbContext;
    }

    public IActionResult Index()
    {
        var alumnos = appDbContext.Alumnos.ToList();
        return View(alumnos);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
