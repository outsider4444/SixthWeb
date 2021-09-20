using Microsoft.AspNetCore.Mvc;
using SixthWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixthWeb.Controllers
{
    public class MaterialController : Controller
    {
        List<Material> materials;
        private ApplicationContext db;
        public MaterialController(ApplicationContext context)
        {
            db = context;
        }
        public IActionResult List()
        {
            return View(db.Materials);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Material material)
        {
            db.Materials.Add(material);
            await db.SaveChangesAsync();
            return RedirectToAction("List");
        }
    }
}
