using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JoelHiltonsFilmCollection.Models;

namespace JoelHiltonsFilmCollection.Controllers;

public class HomeController : Controller
{
    private MovieContext _context;
    
    public HomeController(MovieContext temp)
    {
        _context = temp;
    }
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult InfoJoel()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult EnterMovie()
    {
        return View("EnterMovie");
    }

    [HttpPost]
    public IActionResult EnterMovie(NewMovie newMovie)
    {
        _context.Movies.Add(newMovie);
        _context.SaveChanges();
        
        return RedirectToAction("Index");
    }

    public IActionResult MovieList()
    {
        var movies = _context.Movies
            .ToList();
        return View(movies);

    }

}