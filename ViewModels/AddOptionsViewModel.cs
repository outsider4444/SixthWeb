using SixthWeb.Models;
using System.Collections.Generic;

namespace SixthWeb.ViewModels
{
    public class AddOptionsViewModel
    {
        public int QuestionId { get; set; }
        public int OptionsId { get; set; }
        public Question Question { get; set; }
        public List<Option> Options { get; set; }

        //Передаем варианты ответов в виде списка, на случай если их нужно добавить много за раз
        public AddOptionsViewModel(Question theQuestion, List<Option> possibleOptions)
        {
            Options = new List<Option>();

            foreach (Option option in possibleOptions)
            {
                Options.Add(new Option
                {
                    Value = option.Value,
                    Label = option.Label
                });
            }

            Question = theQuestion;
        }

        public AddOptionsViewModel() { }
    }
}
