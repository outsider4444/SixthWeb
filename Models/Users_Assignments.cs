using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixthWeb.Models
{
    // Пользователи-Задачи (не работают пока что)
    public class Users_Assignment
    {
        public int Id { get; set; }
        public string Status { get; set; }

        public string UserId { get; set; }
        public List<User> Users { get; set; } = new List<User>();

        public int AssignmentId { get; set; }
        public List<Assignment> Assignments { get; set; } = new List<Assignment>();
    }
}
