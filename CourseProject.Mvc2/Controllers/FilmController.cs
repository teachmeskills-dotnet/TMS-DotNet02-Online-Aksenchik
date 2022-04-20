using CourseProject.Mvc2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml;
using System;
using CourseProject.Mvc2.Interfaces;
using CourseProject.Web.Shared.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace CourseProject.Mvc2.Controllers
{
   
    public class FilmController : Controller
    {
        private readonly ApplicationContext _context;
        public readonly IWebHostEnvironment _appEnvironment;
        private readonly IFilmService _filmService;


        public FilmController(ApplicationContext context, IWebHostEnvironment appEnvironment, IFilmService filmService)
        {
            _context = context;
            _appEnvironment = appEnvironment;
            _filmService = filmService ?? throw new ArgumentNullException(nameof(filmService));
        }
        
        public async Task<IActionResult> Create()
        {
            return View(await _context.Films.ToListAsync());
        }

        public async Task<IActionResult> Index(int? id)
        {

            if (id != null)
            {
                Film film = await _context.Films.FirstOrDefaultAsync(p => p.Id == id);
                if (film != null)
                {
                    FilmModelResponse model = new()
                    {
                        Id = film.Id,
                        NameFilms = film.NameFilms,
                        PathPoster = film.PathPoster,
                        ReleaseDate = film.ReleaseDate,
                        AgeLimit = film.AgeLimit,
                        Time = film.Time,
                        Description = film.Description,
                    };

                    return View(film);
                }
            }
            return NotFound();
        }

        public IActionResult AddFilms()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFilms(FilmCreateRequest request)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            var token = User.FindFirst(ClaimTypes.Name).Value;
            await _filmService.AddAsync(request, token);
            return RedirectToAction("Index", "Home");
        }

        //[HttpPost]
        //public async Task<IActionResult> AddFilms(Film addFilm, IFormFile uploadedFile)
        //{
        //    if (uploadedFile != null)
        //    {
        //        // путь к папке Files
        //        string path = "/Files/" + uploadedFile.FileName;
        //        // сохраняем файл в папку Files в каталоге wwwroot
        //        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
        //        {
        //            await uploadedFile.CopyToAsync(fileStream);
        //        }

        //        Film file = new() { Id = addFilm.Id,
        //                            ImageName = uploadedFile.FileName,
        //                            PathPoster = path,
        //                            NameFilms = addFilm.NameFilms,
        //                            AgeLimit = addFilm.AgeLimit,
        //                            ReleaseDate = addFilm.ReleaseDate,
        //                            Time = addFilm.Time,
        //                            Description = addFilm.Description,
        //                            IdRating = addFilm.IdRating,
        //                            RatingImdb = addFilm.RatingImdb,
        //                            RatingKinopoisk = addFilm.RatingKinopoisk,
        //                            RatingSite = addFilm.RatingSite
        //                            //GenreName = addFilm.GenreName,
        //                            //StageManagers = addFilm.StageManagers,
        //                            //RatingSite = addFilm.RatingSite
        //        };
        //        var idRating = file.IdRating;
        //        Uri baseURI = new Uri("https://rating.kinopoisk.ru/");
        //        Uri XmlPuth = new Uri(baseURI, $"{idRating}.xml");
        //        string xmlStr;
        //        using (var wc = new WebClient())
        //        {
        //            xmlStr = wc.DownloadString(XmlPuth);
        //        }
        //        var xmlDoc = new XmlDocument();
        //        xmlDoc.LoadXml(xmlStr);

        //        if (xmlDoc is not null)
        //        {
        //            XmlNodeList saveItems = xmlDoc.SelectNodes("rating");
        //            XmlNode kinopoisk = saveItems.Item(0).SelectSingleNode("kp_rating");
        //            XmlNode imdb = saveItems.Item(0).SelectSingleNode("imdb_rating");
        //            string kinopoiskData = kinopoisk.InnerText;
        //            string ImdbData = imdb.InnerText;
        //            file.RatingImdb = ImdbData;
        //            file.RatingKinopoisk = kinopoiskData;
        //        }
        //        _context.Films.Add(file);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Film film = await _context.Films.FirstOrDefaultAsync(p => p.Id == id);
                if (film != null)
                    return View(film);
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Film film = await _context.Films.FirstOrDefaultAsync(p => p.Id == id);
                if (film != null)
                    return View(film);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Film film)
        {
            _context.Films.Update(film);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Film film = await _context.Films.FirstOrDefaultAsync(p => p.Id == id);
                if (film != null)
                    return View(film);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Film film = await _context.Films.FirstOrDefaultAsync(p => p.Id == id);
                if (film != null)
                {
                    _context.Films.Remove(film);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
            
        }

        //[HttpPost]
        //public async Task<IActionResult> XmlRating(string xmlId)
        //{
            
        //    return RedirectToAction("Index");
        //}
    }
}
