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
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName).ToList();
        return View("EnterMovie");
    }

    [HttpPost]
    public IActionResult EnterMovie(NewMovie newMovie)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = _context.Categories
                .ToList();
            return View("MovieList", newMovie);
        }
        _context.Movies.Add(newMovie);
        _context.SaveChanges();
        
        return RedirectToAction("Index");
    }

    public IActionResult MovieList()
    {
        var movies = _context.Movies
            .OrderBy(x => x.MovieId).ToList();
        return View(movies);

    }

    
    [HttpGet]
    public IActionResult Edit(int id)
    {

        var movieToEdit = _context.Movies
            .Single(x => x.MovieId == id);
        
        ViewBag.Categories = _context.Categories
            .ToList();
        
        return View("EnterMovie", movieToEdit);
    }

    [HttpPost]
    public IActionResult Edit(NewMovie updatedMovie)
    {
        _context.Update(updatedMovie);
        _context.SaveChanges();
        return RedirectToAction("MovieList");
    }

    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies.Single(x => x.MovieId == id);
        
        return View("Delete", recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(NewMovie movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        return RedirectToAction("MovieList");
    }
}