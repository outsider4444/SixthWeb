using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            ViewBag.UserRole = HttpContext.User.IsInRole("Ментор");
            ViewBag.UsersId = db.Users.ToList();
            ViewBag.Users = db.Users.ToList();
            var ABC = db.Assignments.ToList();
            return View(ABC);
        }

        public async Task<IActionResult> Detail(int? id)
        {

            ViewBag.UsersId = db.Users.ToList();
            ViewBag.Users = db.Users.ToList();

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
            ViewBag.Users = db.Users.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Assignment assignment)
        {
            db.Assignments.Add(assignment);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // Редактирование объекта
        public async Task<IActionResult> Edit(int? id)
        {

            ViewBag.Users = db.Users.ToList();
            ViewBag.UserRole = HttpContext.User.IsInRole("Ментор");
            ViewBag.Title = "Редактирование задачи";

            if (id != null)
            {
                Assignment item = await db.Assignments.FirstOrDefaultAsync(p => p.Id == id);
                if (item != null)
                    return View(item);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Assignment item)
        {
            db.Assignments.Update(item);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Ментор")]
        // Страница удаления
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            ViewBag.Title = "Удаление задачи";
            if (id != null)
            {
                Assignment item = await db.Assignments.FirstOrDefaultAsync(p => p.Id == id);
                if (item != null)
                    return View(item);
            }
            return NotFound();
        }

        // Функция удаления
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Assignment item = await db.Assignments.FirstOrDefaultAsync(p => p.Id == id);
                if (item != null)
                {
                    db.Assignments.Remove(item);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
