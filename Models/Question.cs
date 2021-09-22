using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SixthWeb.Models
{
    // Задачи для пользователей
    public class Question
    {
        public User User { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int SurveyId {  get; set; }

        [Required(ErrorMessage = "Не забудьте про ответ на вопрос!")]
        public string Answer { get; set; }

        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<Option> Options { get; set; }

        public Question()
        {
        }

        public Question(string text, string answer, List<Option> options)
        {
            Text = text;
            Answer = answer;
            Options = options;
        }
    }
}
