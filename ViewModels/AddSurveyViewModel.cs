using SixthWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SixthWeb.ViewModels
{
    public class AddSurveyViewModel
    {
        [Required(ErrorMessage = "Test name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Test name must be between 3 and 50 characters")]
        public string NameOfSurvey { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description too long!")]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public List<Question> Questions { get; set; }
        public List<Option> Options { get; set; }



        public AddSurveyViewModel(List<Question> questions, List<Option> options)
        {
            Questions = questions;
            Options = options;
        }

        public AddSurveyViewModel() { }
    }
}
