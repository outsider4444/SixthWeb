using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixthWeb.Models;
using SixthWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SixthWeb.Controllers
{
    //Контроллер тестов
    public class SurveyController : Controller
    {
        private ApplicationContext db;
        public SurveyController(ApplicationContext context)
        {
            db = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            List<Survey> surveys = db.Surveys.ToList();

            return View(surveys);
        }
        [HttpGet]
        public IActionResult Add()
        {
            AddSurveyViewModel addTestViewModel = new AddSurveyViewModel();
            return View(addTestViewModel);
        }

        [HttpPost]
        public IActionResult ProcessAddTestForm([FromBody] AddSurveyViewModel addTestViewModel)
        {
            if (ModelState.IsValid)
            {
                Survey newSurvey = new Survey
                {
                    NameOfSurvey = addTestViewModel.NameOfSurvey,
                    Description = addTestViewModel.Description,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                };

                db.Surveys.Add(newSurvey);
                db.SaveChanges();

                foreach (Question question in addTestViewModel.Questions)
                {
                    Question newQuestion = new Question
                    {
                        SurveyId = newSurvey.Id,
                        Text = question.Text,
                        Answer = question.Answer,
                    };

                    db.Questions.Add(newQuestion);
                    db.SaveChanges();

                    if (question.Options != null)
                    {

                        foreach (Option option in question.Options)
                        {
                            Option newOption = new Option
                            {
                                QuestionId = newQuestion.Id,
                                Value = option.Value,
                                Label = option.Label
                            };
                            db.Options.Add(newOption);
                            db.SaveChanges();
                        }
                    }

                }
                return Redirect("/Test/Details/" + newSurvey.Id);
            }
            return View("Add", addTestViewModel);
        }

        [HttpGet]
        public IActionResult Delete(int testId)
        {
            Survey theSurvey = db.Surveys.Find(testId);
            db.Surveys.Remove(theSurvey);
            db.SaveChanges();

            return Redirect("/Test");
        }

        [HttpGet]
        [Route("/Test/UpdateTest/{testId?}")]
        public IActionResult UpdateTest(int testId)
        {
            Survey theTest = db.Surveys
                .Include(t => t.Questions)
                    .ThenInclude(q => q.Options)
                .Single(t => t.Id == testId);

            return View(theTest);

        }

        [HttpPost]
        [Route("/Test/UpdateTest/{testId}")]
        public IActionResult UpdateTest(EditSurveyViewModel editTest, int testId)
        {
            Survey survey = db.Surveys
                .Include(t => t.Questions)
                .ThenInclude(q => q.Options)
                .Single(t => t.Id == testId);

            if (survey == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                survey.Description = editTest.Description;
                survey.NameOfSurvey = editTest.NameOfTest;
                survey.UpdatedAt = DateTime.Now;

                foreach (Question question in editTest.Questions)
                {
                    Question existingQuestion = db.Questions.SingleOrDefault(q => q.Id == question.Id);

                    existingQuestion.Text = question.Text;
                    existingQuestion.Answer = question.Answer;

                    if (question.Options != null)
                    {
                        foreach (Option option in question.Options)
                        {
                            Option existingOption = db.Options.SingleOrDefault(o => o.Id == option.Id);
                            existingOption.Label = option.Label;
                        }
                    }
                }


                db.SaveChanges();
                return Redirect("/Test/Details/" + survey.Id);
            }



            return View("/Index");
        }

    }
}
