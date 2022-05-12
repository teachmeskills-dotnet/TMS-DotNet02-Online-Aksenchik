﻿using CourseProject.Mvc2.Interfaces;
using CourseProject.Web.Shared.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CourseProject.Mvc2.Controllers
{
    /// <summary>
    /// Account controller.
    /// </summary>
    public class AccountController : Controller
    {
        public readonly IIdentityService _identityService;
        private readonly IFilmService _filmService;

        /// <summary>
        /// Constructor with params.
        /// </summary>
        /// <param name="filmService">Film Service.</param>
        /// <param name="identityService">Identity Service.</param>
        public AccountController(IIdentityService identityService, IFilmService filmService)
        {
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _filmService = filmService ?? throw new ArgumentNullException(nameof(filmService));
        }

        /// <summary>
        /// Login (Get).
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> LoginAsync()
        {
            var viewModel = new UserLoginRequest();
            var filmCollection = await _filmService.GetAllShortAsync();
            var genreCollection = await _filmService.GetAllGenreAsync();
            var resultRandomFilm = await _filmService.GetRandomFilmByIdAsync();

            ViewBag.RandomFilm = resultRandomFilm.Id;
            ViewBag.Genres = genreCollection;
            ViewBag.Films = filmCollection;

            return View(viewModel);
        }

        /// <summary>
        /// Login (Post).
        /// </summary>
        /// <param name="request">User login request.</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(UserLoginRequest request)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            if (ModelState.IsValid)
            {
                var (roles, userName) = await _identityService.LoginAsync(request);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Email, userName)
                };

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }

            // UNDONE: ModelError

            return View(request);
        }

        /// <summary>
        /// Register (Get).
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> RegisterAsync()
        {
            var filmCollection = await _filmService.GetAllShortAsync();
            var genreCollection = await _filmService.GetAllGenreAsync();
            var resultRandomFilm = await _filmService.GetRandomFilmByIdAsync();

            ViewBag.RandomFilm = resultRandomFilm.Id;
            ViewBag.Genres = genreCollection;
            ViewBag.Films = filmCollection;
            if (User.Identity.IsAuthenticated == false)
            {
                var viewModel = new UserRegistationRequest();
                return View(viewModel);
                
            }
            
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Register (Post).
        /// </summary>
        /// <param name="request">User registation request.</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAsync(UserRegistationRequest request)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            if (ModelState.IsValid)
            {

                 await _identityService.RegisterAsync(request);
                
                return RedirectToAction("Index", "Home");
            }

                return View(request);
        }

        /// <summary>
        /// User logout(Post).
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// User profile view(Get).
        /// </summary>
        /// <param name="userName">User name.</param>
        [HttpGet]
        public async Task<IActionResult> Profile(string userName)
        {
            var filmCollection = await _filmService.GetAllShortAsync();
            var genreCollection = await _filmService.GetAllGenreAsync();
            var resultRandomFilm = await _filmService.GetRandomFilmByIdAsync();

            ViewBag.RandomFilm = resultRandomFilm.Id;
            ViewBag.Genres = genreCollection;
            ViewBag.Films = filmCollection;
            var token = User.FindFirst(ClaimTypes.Name).Value;
            var result = await _identityService.GetProfileByNameAsync(userName, token);
            return View(result);
        }
    }
}
