using Course_Project.Data.Models;
using Course_Project.Logic.Interfaces;
using CourseProject.WebApi3.Contracts.Requests;
using CourseProject.WebApi3.Contracts.Responses;
using CourseProject.WebApi3.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.WebApi3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IJwtService _jwtService;
        private readonly AppSettings _appSettings;

        public UserController(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IJwtService jwtService,
            IOptions<AppSettings> appSettings)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService));

            if (appSettings is null)
            {
                throw new ArgumentNullException(nameof(appSettings));
            }
            _appSettings = appSettings.Value;
        }


        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(UserLoginRequest model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                return BadRequest(new { message = "Неправильный логин и (или) пароль" });
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            var token = _jwtService.GenerateJwtToken(user.Id, _appSettings.Secret);
            var userRoles = await _userManager.GetRolesAsync(user);
            var response = new AuthenticateResponse(user, token, userRoles);

            return Ok(response);
        }

        [HttpPost("registration")]
        public async Task<IActionResult> RegistrationAsync(UserRegistationRequest request)
        {
            var user = new User
            {
                Email = request.Email,
                UserName = request.Email
            };

            if (request.Password == request.PasswordConfirm)
            {
                var result = await _userManager.CreateAsync(user, request.Password);
                await _userManager.AddToRoleAsync(user, "User");

                if (!result.Succeeded)
                {

                    return BadRequest(new ErrorResponse<string>
                    {
                        Message = "Can't registration new user.",
                        
                    });
                }
            }
            else
            {
                return BadRequest(new ErrorResponse<string>
                {
                    Message = "Пароли не совпадают."
                });
            }

            var token = _jwtService.GenerateJwtToken(user.Id, _appSettings.Secret);
            var userRoles = await _userManager.GetRolesAsync(user);
            var response = new AuthenticateResponse(user, token, userRoles);

            return Ok(response);
        }

        [HttpPost("logout")]
        public async Task<OkResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        //[HttpPost("registration")]
        //public async Task<IActionResult> RegistrationAsync(UserRegistationRequest model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        User user = new() { Email = model.Email, UserName = model.UserName };
        //        var result = await _userManager.CreateAsync(user, model.Password);
        //        if (result.Succeeded)
        //        {
        //            await _signInManager.SignInAsync(user, false);
        //            //await _userManager.AddToRoleAsync(user, "User");
        //        }
        //        else
        //        {
        //            return BadRequest(new ErrorResponse<string>
        //            {
        //                Message = "Can't registration new user.",
        //                Errors = result.Errors.Select(error => error.Description)
        //            });
        //        }
        //    }
        //    return Ok(model);
        //}

        //[HttpPost("login")]
        //public async Task<IActionResult> LoginAsync(UserLoginRequest model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
        //        if (!result.Succeeded)
        //        {
        //            return BadRequest(new { message = "Email or password is incorrect" });
        //        }
        //    }

        //    return Ok(model);
        //}

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteAsync(string id)
        //{
        //    User user = await _userManager.FindByIdAsync(id);
        //    if (user != null)
        //    {
        //        var result = await _userManager.DeleteAsync(user);
        //    }
        //    return Ok();
        //}
    }
}
