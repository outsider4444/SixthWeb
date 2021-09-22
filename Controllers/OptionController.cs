using Microsoft.AspNetCore.Mvc;
using SixthWeb.Models;
using SixthWeb.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SixthWeb.Controllers
{
    public class OptionController : Controller
    {
        private ApplicationContext db;
        public OptionController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            List<Question> questions = db.Questions.ToList();

            return View(questions);
        }

        public IActionResult Add()
        {
            AddQuestionViewModel addQuestionViewModel = new AddQuestionViewModel();
            return View(addQuestionViewModel);
        }

        [HttpPost]
        public IActionResult ProcessAddQuestionForm(AddQuestionViewModel addQuestionViewModel)
        {
            if (ModelState.IsValid)
            {
                Question newQuestion = new Question
                {
                    Text = addQuestionViewModel.Text,
                    Answer = addQuestionViewModel.Answer,
                    Options = addQuestionViewModel.Options
                };
                db.Questions.Add(newQuestion);
                db.SaveChanges();

                return Redirect("Question");
            }

            return View("Add", addQuestionViewModel);

        }

        [HttpPost]
        [Route("/Question/DeleteQuestion/{questionId}")]
        public ActionResult DeleteQuestion(int questionId)
        {
            Question theQuestion = db.Questions.Find(questionId);
            db.Questions.Remove(theQuestion);
            db.SaveChanges();

            return Ok();
        }
    }
}
