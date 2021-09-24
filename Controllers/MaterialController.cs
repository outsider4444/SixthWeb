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
        private ApplicationContext db;
        public MaterialController(ApplicationContext context)
        {
            db = context;
        }
        public IActionResult List()
        {
            ViewBag.Title = "Список статей";
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
            ViewBag.Title = "Создание новой статьи";
            db.Materials.Add(material);
            await db.SaveChangesAsync();
            return RedirectToAction("List");
        }

        // Редактирование объекта
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Title = "Редактирование статьи";
            if (id != null)
            {
                Material item = await db.Materials.FirstOrDefaultAsync(p => p.Id == id);
                if (item != null)
                    return View(item);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Material item)
        {
            db.Materials.Update(item);
            await db.SaveChangesAsync();
            return RedirectToAction("List");
        }

        // Страница удаления
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            ViewBag.Title = "Удаление статьи";
            if (id != null)
            {
                Material item = await db.Materials.FirstOrDefaultAsync(p => p.Id == id);
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
                Material item = await db.Materials.FirstOrDefaultAsync(p => p.Id == id);
                if (item != null)
                {
                    db.Materials.Remove(item);
                    await db.SaveChangesAsync();
                    return RedirectToAction("List");
                }
            }
            return NotFound();
        }
    }

}
