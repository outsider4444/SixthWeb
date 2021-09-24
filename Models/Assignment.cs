using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixthWeb.Models
{
    // Задачи для пользователя
    public class Assignment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }

        // Время на выполнение задачи
        public DateTime TimeDate { get; set; }

    }

    // Сделать чтобы все задачи были привязаны к пользователям

}
