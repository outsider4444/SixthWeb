using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixthWeb.Models
{
    public class Users_Assignment
    {
        public int Id { get; set; }
        public string Status { get; set; }

        public string UserId { get; set; }
        public  User Users{ get; set; }

        public int AssignmentId { get; set; }
        public Assignment Assignments { get; set; }
    }
}
