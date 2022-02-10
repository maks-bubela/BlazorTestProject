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
                Password = "+LHZUmFT7CmKe7fALiqT/GtMKo4D0An0EH2XDiPSt0U=",
                Salt = "sdiBc/RhuqW8wEZWtmDixw==",
                Firstname = "admin",
                Lastname = "admin",
                RoleId = 1
            });

            modelBuilder.Entity<EnvironmentType>().HasData(
                new EnvironmentType { Id = 1, Name = "staging" },
                new EnvironmentType { Id = 2, Name = "development" },
                new EnvironmentType { Id = 3, Name = "testing" },
                new EnvironmentType { Id = 4, Name = "production" }
            );

            modelBuilder.Entity<BearerTokenSetting>().HasData(
                new BearerTokenSetting { Id = 1, EnvironmentTypeId = 1, LifeTime = 30 },
                new BearerTokenSetting { Id = 2, EnvironmentTypeId = 2, LifeTime = 30 },
                new BearerTokenSetting { Id = 3, EnvironmentTypeId = 3, LifeTime = 1 },
                new BearerTokenSetting { Id = 4, EnvironmentTypeId = 4, LifeTime = 7 }
            );
        }
    }
}
