using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixthWeb.Controllers
{
    public class ResultsController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
