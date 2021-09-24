using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixthWeb.Controllers
{

    //Наверное стоит выводить здесь как за тест,
    //так и за вопросы по статьям,
    //а так же по задачам пользователей
    public class ResultsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
