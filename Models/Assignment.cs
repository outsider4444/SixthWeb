﻿using System;
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
        public string Status { get; set; }

        // Время на выполнение задачи
        public DateTime TimeDate { get; set; }

        public string UserId { get; set; }
        public User User{ get; set; }  // компания пользователя

        //public List<Users_Assignment> Users_Assignments { get; set; } = new List<Users_Assignment>();

    }

    // Сделать чтобы все задачи были привязаны к пользователям

}