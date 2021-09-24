using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SixthWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SixthWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context) // ApplicationContext для бд
        {
            _logger = logger;

            db = context;
        }
        private ApplicationContext db;
        // Вывод данных из БД с пользователями, для того чтобы выводить о них информацию
        public IActionResult Index()
        {
            return View(db.Users);
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
