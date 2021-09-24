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
        private Func<DbContextOptions<ApplicationContext>> getRequiredService;

        // Добавление моделей в БД
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public ApplicationContext(Func<DbContextOptions<ApplicationContext>> getRequiredService)
        {
            this.getRequiredService = getRequiredService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
