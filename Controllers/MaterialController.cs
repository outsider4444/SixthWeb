using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixthWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixthWeb.Controllers
{
    public class MaterialController : Controller
    {
        // List<Material> materials;
        private ApplicationContext db;
        public MaterialController(ApplicationContext context)
        {
            db = context;
        }
        public IActionResult List()
        {
            var ABC = db.Materials.ToList();
            return View(ABC);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id != null)
            {
                Material item = await db.Materials.FirstOrDefaultAsync(p => p.Id == id);
                if (item != null)
                    return View(item);
            }
            return NotFound();
        }

        // Добавить страничку с созданием/редактированием вопроса к статье

        [HttpGet]
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
