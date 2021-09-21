using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixthWeb.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        // Добавление моделей в БД
        public DbSet<Material> Materials { get; set; }
        public DbSet<Mquestion> Mquestions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
