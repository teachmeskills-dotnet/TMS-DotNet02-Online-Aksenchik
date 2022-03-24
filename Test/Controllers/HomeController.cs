using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;
using Test.ViewModels;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _context;

        public HomeController(ApplicationContext context)
        {
            _context = context;

            //Phone phone = new()
            //{
            //    new Phone { Id=1, Manufacturer= apple, Name="iPhone X", Price=56000 },
            //    new Phone { Id=2, Manufacturer= apple, Name="iPhone XZ", Price=41000 },
            //    new Phone { Id=3, Manufacturer= microsoft, Name="Galaxy 9", Price=9000 },
            //    new Phone { Id=4, Manufacturer= microsoft, Name="Galaxy 10", Price=40000 },
            //    new Phone { Id=5, Manufacturer= google, Name="Pixel 2", Price=30000 },
            //    new Phone { Id=6, Manufacturer= google, Name="Pixel XL", Price=50000 }
            //};
        }

        public IActionResult Index()
        {
            //// формируем список компаний для передачи в представление
            //List<CompanyModel> compModels = Companies
            //    .Select(c => new CompanyModel { Id = c.Id, Name = c.Name })
            //    .ToList();
            //// добавляем на первое место
            //compModels.Insert(0, new CompanyModel { Id = 0, Name = "Все" });

            //IndexViewModel ivm = new IndexViewModel { Companies = compModels, Phones = phones };

            //// если передан id компании, фильтруем список
            //if (companyId != null && companyId > 0)
            //    ivm.Phones = phones.Where(p => p.Manufacturer.Id == companyId);

            return View(/*ivm*/);
        }

        public IActionResult Privacy()
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