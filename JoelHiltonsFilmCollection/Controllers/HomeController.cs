using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JoelHiltonsFilmCollection.Models;

namespace JoelHiltonsFilmCollection.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult InfoJoel()
    {
        return View();
    }
    
    public IActionResult EnterMovie()
    {
        return View();
    }

    
}