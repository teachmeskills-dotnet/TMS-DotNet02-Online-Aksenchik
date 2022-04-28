using CourseProject.Mvc2.Interfaces;
using CourseProject.Web.Shared.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CourseProject.Mvc2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFilmService _filmService;

        public HomeController(IFilmService filmService)
        {
            _filmService = filmService ?? throw new ArgumentNullException(nameof(filmService));
        }

        public async Task<IActionResult> Index()
        {
            var result = await _filmService.GetAllShortAsync();
            var genreCollection = await _filmService.GetAllGenreAsync();
            ViewBag.Genres = genreCollection;
            ViewBag.Films = result;
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string name)
        {
            var filmCollection = await _filmService.GetAllShortAsync();
            var genreCollection = await _filmService.GetAllGenreAsync();
            ViewBag.Genres = genreCollection;
            ViewBag.Films = filmCollection;
            var result = await _filmService.GetByNameAsync(name);

            return View(result);
        }

        public IActionResult Registration()
        {
            return View();
        }
    }
}
