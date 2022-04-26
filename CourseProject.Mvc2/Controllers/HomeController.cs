using CourseProject.Mvc2.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            var token = User.FindFirst(ClaimTypes.Name).Value;
            var result = await _filmService.GetAllShortAsync(token);
            return View(result);
        }

        public IActionResult Registration()
        {
            return View();
        }
    }
}
