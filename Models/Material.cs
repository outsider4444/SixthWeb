using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixthWeb.Models
{
    // Статья
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }

        
    }

    // Пусть в материале лежит тогда только сам материал, а вопросы к статье в Question.cs
    /* Вопрос к Статье
     public class Mquestion
     {
         public int Id { get; set; }
         public string Name { get; set; }

         // Добавление вопроса к статье (Попровьте если ошибся)
         public Material Material { get; set; }
     }

     // Ответ к вопросу
     public class Answer
     {
         public int Id { get; set; }
         public string Name { get; set; }

         // Ответ на вопрос (Попровьте если ошибся)
         public Mquestion Question { get; set; }
     }
    */
}
