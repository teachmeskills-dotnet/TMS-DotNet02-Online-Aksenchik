using Course_Project.Data.Models;
using CourseProject.Mvc2.Interfaces;
using CourseProject.Web.Shared.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CourseProject.Mvc2.Controllers
{
    public class AccountController : Controller
    {
        public readonly IIdentityService _identityService;

        public AccountController(IIdentityService identityService)
        {
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }

        /// <summary>
        /// Login (Get).
        /// </summary>
        [HttpGet]
        public IActionResult Login()
        {
            var viewModel = new UserLoginRequest();

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
                var (token, roles) = await _identityService.LoginAsync(request);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, token),
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
        /// Login (Get).
        /// </summary>
        [HttpGet]
        public IActionResult Register()
        {
            var viewModel = new UserRegistationRequest();

            return View(viewModel);
        }

        /// <summary>
        /// Login (Post).
        /// </summary>
        /// <param name="request">User login request.</param>
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        //[HttpGet]
        //public IActionResult Register()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        User user = new() { Email = model.Email, UserName = model.UserName};
        //        // добавляем пользователя
        //        var result = await _userManager.CreateAsync(user, model.Password);
        //        if (result.Succeeded)
        //        {
        //            // установка куки
        //            await _signInManager.SignInAsync(user, false);
        //            await _userManager.AddToRoleAsync(user, "Users");
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError(string.Empty, error.Description);
        //            }
        //        }
        //    }
        //    return View(model);
        //}

        //[HttpGet]
        //public IActionResult Login(string returnUrl = null)
        //{
        //    return View(new LoginViewModel { ReturnUrl = returnUrl });
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(LoginViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
        //        if (result.Succeeded)
        //        {
        //            // проверяем, принадлежит ли URL приложению
        //            if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
        //            {
        //                return Redirect(model.ReturnUrl);
        //            }
        //            else
        //            {
        //                return RedirectToAction("Index", "Home");
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Неправильный логин и (или) пароль");
        //        }
        //    }
        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> LoginAsync(LoginViewModel request)
        //{
        //    request = request ?? throw new ArgumentNullException(nameof(request));

        //    if (ModelState.IsValid)
        //    {

        //        return RedirectToAction("Index", "Home");
        //    }

        //    // UNDONE: ModelError

        //    return View(request);
        //}



        //public async Task<IActionResult> Profile(string userName)
        //{
        //    User user = await _userManager.FindByNameAsync(userName);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        ProfileUserViewModel model = new()
        //        {
        //            Id = user.Id,
        //            Email = user.Email,
        //            UserName = user.UserName
        //        };
        //        return View(model);
        //    }
        //}
    }
}
