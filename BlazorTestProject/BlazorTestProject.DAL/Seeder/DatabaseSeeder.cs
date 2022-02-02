using BlazorTestProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorTestProject.DAL.Seeder
{
    class DatabaseSeeder
    {
        public static void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                    new Role() { Id = 1, RoleName = "admin" },
                    new Role() { Id = 2, RoleName = "staff" },
                    new Role() { Id = 3, RoleName = "customer" }
                );
            modelBuilder.Entity<User>().HasData(
            new User{
                Id = 1,
                Username = "admin",
                Password = "admin",
                Firstname = "admin",
                Lastname = "admin",
                RoleId = 1
            });
        }
    }
}
