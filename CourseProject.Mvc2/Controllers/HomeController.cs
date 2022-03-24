using CourseProject.Mvc2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CourseProject.Mvc2.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _context;

        public HomeController(ApplicationContext context/*, ILogger<HomeController> logger*/)
        {
            //_logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Films.ToListAsync());
        }

        public IActionResult Registration()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
