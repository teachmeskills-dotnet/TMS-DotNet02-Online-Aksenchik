using CourseProject.Mvc2.Interfaces;
using CourseProject.Mvc2.ViewModels;
using CourseProject.Web.Shared.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

        public async Task<IActionResult> Index(int page = 1)
        {
            var result = await _filmService.GetAllShortAsync();
            int pageSize = 3;
            var count = result.Count();
            var items = result.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                FilmShortModelResponses = items
            };

            var genreCollection = await _filmService.GetAllGenreAsync();
            var resultRandomFilm = await _filmService.GetRandomFilmByIdAsync();

            ViewBag.RandomFilm = resultRandomFilm.Id;
            ViewBag.Genres = genreCollection;
            ViewBag.Films = result;
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string name)
        {
            var filmCollection = await _filmService.GetAllShortAsync();
            var genreCollection = await _filmService.GetAllGenreAsync();
            var resultRandomFilm = await _filmService.GetRandomFilmByIdAsync();

            ViewBag.RandomFilm = resultRandomFilm.Id;
            ViewBag.Genres = genreCollection;
            ViewBag.Films = filmCollection;
            var result = await _filmService.GetByNameAsync(name);

            return View(result);
        }
    }
}
