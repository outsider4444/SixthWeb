using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixthWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixthWeb.Controllers
{
    // Контроллер заданий для пользователей
    public class AssignmentController : Controller
    {
        private ApplicationContext db;
        public AssignmentController(ApplicationContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var ABC = db.Assignments.ToList();
            return View(ABC);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id != null)
            {
                Assignment item = await db.Assignments.FirstOrDefaultAsync(p => p.Id == id);
                if (item != null)
                    return View(item);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Assignment assignment)
        {
            db.Assignments.Add(assignment);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
