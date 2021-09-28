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
        public DbSet<Users_Assignment> Users_Assignments { get; set; }

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
            modelBuilder.Entity<Users_Assignment>()
                .HasOne(b => b.Assignments)
                .WithMany(ba => ba.Users_Assignments)
                .HasForeignKey(bi => bi.AssignmentId);

            modelBuilder.Entity<Users_Assignment>()
              .HasOne(b => b.Users)
              .WithMany(ba => ba.Users_Assignments)
              .HasForeignKey(bi => bi.UserId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Assignment> assignments{ get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Users_Assignment> users_Assignments{ get; set; }
    }
}
