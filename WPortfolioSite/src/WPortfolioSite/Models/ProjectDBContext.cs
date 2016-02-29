using Microsoft.Data.Entity;
using System;

namespace WPortfolioSite.Models
{
    public class ProjectDBContext : DbContext
    {
        public DbSet<ProjectFile> Files { get; set; }
        public DbSet<Project> Projects { get; set; }

        public ProjectDBContext()
        {
            try {
                Database.EnsureCreated();
            }
            catch(Exception e)
            {
                return;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=wportfoliodb.c6nmwrhmqleh.us-west-2.rds.amazonaws.com;Database=wPortfolio;User Id=wpAdmin;Password=4b44454b");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ForSqlServerUseIdentityColumns();
        }
    }
}
