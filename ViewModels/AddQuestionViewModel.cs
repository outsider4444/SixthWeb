using SixthWeb.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SixthWeb.ViewModels
{
    public class AddQuestionViewModel
    {
        [Required(ErrorMessage = "Текст обязателен.")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Вопрос должен состоять более чем из трех символов и быть меньше 500 символов.")]
        public string Text { get; set; }

        [Required]
        public List<Option> Options { get; set; }

        [Required(ErrorMessage = "Правильный ответ обязателен")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Ответ состоит из 1-100 символов")]
        public string Answer { get; set; }

        public AddQuestionViewModel(Question question)
        {
            Text = question.Text;
            Options = question.Options;
        }

        public AddQuestionViewModel() { }
    }
}
