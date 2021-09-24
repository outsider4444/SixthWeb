using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixthWeb.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        
        // Является ли пользователь ментором
        public bool IsMentor { get; set; }

        // Задачи для пользователя
        public List<Assignment> Assignments { get; set; } = new List<Assignment>();

    }
}
