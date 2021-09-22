using System;
using System.Collections.Generic;

namespace SixthWeb.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public string NameOfSurvey { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<Question> Questions { get; set; }

        public Survey()
        {

        }

        public Survey(string nameOfSurvey, string description, string status, DateTime createdAt, DateTime updatedAt)
        {
            NameOfSurvey = nameOfSurvey;
            Description = description;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
