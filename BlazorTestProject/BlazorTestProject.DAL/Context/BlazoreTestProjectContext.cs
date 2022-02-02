using BlazorTestProject.DAL.Entities;
using BlazorTestProject.DAL.Seeder;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BlazorTestProject.DAL.Context
{
    public class BlazoreTestProjectContext : DbContext
    {
        public BlazoreTestProjectContext(string connectionString) : base(GetOptions(connectionString)) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            DatabaseSeeder.SeedDataBase(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
