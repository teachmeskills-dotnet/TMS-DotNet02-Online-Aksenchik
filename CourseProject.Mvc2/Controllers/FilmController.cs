using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using CourseProject.Mvc2.Interfaces;
using System.Security.Claims;
using CourseProject.Web.Shared.Models.Responses;
using CourseProject.Web.Shared.Models.Request;

namespace CourseProject.Mvc2.Controllers
{
    public class FilmController : Controller
    {
        public readonly IWebHostEnvironment _appEnvironment;
        private readonly IFilmService _filmService;

        public FilmController(IWebHostEnvironment appEnvironment, IFilmService filmService)
        {
            _appEnvironment = appEnvironment;
            _filmService = filmService ?? throw new ArgumentNullException(nameof(filmService));
        }

        public async Task<IActionResult> Index(int id)
        {
                var token = User.FindFirst(ClaimTypes.Name).Value;
                var result = await _filmService.GetByIdAsync(id, token);
                return View(result);
        }

        public IActionResult AddFilms()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFilms(FilmCreateRequest model, IFormFile uploadedFile)
        {
            model = model ?? throw new ArgumentNullException(nameof(model));
            // путь к папке Files
            string path = "/Files/" + uploadedFile.FileName;
            // сохраняем файл в папку Files в каталоге wwwroot
            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }

            var request = new FilmCreateRequest
            {
                ImageName = uploadedFile.FileName,
                PathPoster = path,
                NameFilms = model.NameFilms,
                AgeLimit = model.AgeLimit,
                Time = model.Time,
                ReleaseDate = model.ReleaseDate,
                Description = model.Description,
                IdRating = model.IdRating,
                RatingSite = model.RatingSite,
                CountryIds = model.CountryIds,
                ActorIds = model.ActorIds,
                StageManagerIds = model.StageManagerIds,
                GenreIds = model.GenreIds
            };

            var token = User.FindFirst(ClaimTypes.Name).Value;
            await _filmService.AddAsync(request, token);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AddCount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCount(CountryCreateRequest request)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            var token = User.FindFirst(ClaimTypes.Name).Value;
            await _filmService.AddCountryAsync(request, token);
            return RedirectToAction("Index", "Home");
        }

        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id != null)
        //    {
        //        Film film = await _context.Films.FirstOrDefaultAsync(p => p.Id == id);
        //        if (film != null)
        //            return View(film);
        //    }
        //    return NotFound();
        //}

        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id != null)
        //    {
        //        Film film = await _context.Films.FirstOrDefaultAsync(p => p.Id == id);
        //        if (film != null)
        //            return View(film);
        //    }
        //    return NotFound();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Edit(Film film)
        //{
        //    _context.Films.Update(film);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //[ActionName("Delete")]
        //public async Task<IActionResult> ConfirmDelete(int? id)
        //{
        //    if (id != null)
        //    {
        //        Film film = await _context.Films.FirstOrDefaultAsync(p => p.Id == id);
        //        if (film != null)
        //            return View(film);
        //    }
        //    return NotFound();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id != null)
        //    {
        //        Film film = await _context.Films.FirstOrDefaultAsync(p => p.Id == id);
        //        if (film != null)
        //        {
        //            _context.Films.Remove(film);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    return NotFound();
            
        //}
    }
}
