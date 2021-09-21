using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixthWeb.Models
{
    // Задачи для пользователей
    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }

        // Вероятно стоит добавить поле "Статус выполнения"
    }

    // Привязать задачи к пользователям
}
