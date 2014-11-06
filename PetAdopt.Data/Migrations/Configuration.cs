namespace PetAdopt.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PetAdopt.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PetAdopt.Data.PetAdoptDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PetAdopt.Data.PetAdoptDbContext context)
        {
            this.SeedAdminUser(context);

            if(context.PetTypes.Any())
            {
                return;
            }

            context.PetTypes.AddOrUpdate(
                new PetType { Name = "Cat" },
                new PetType { Name = "Dog" },
                new PetType { Name = "Mouse" },
                new PetType { Name = "Hamster" },
                new PetType { Name = "Lizard" },
                new PetType { Name = "Fish" },
                new PetType { Name = "Spider" },
                new PetType { Name = "Rabbit" },
                new PetType { Name = "Scorpion" },
                new PetType { Name = "Parrot" },
                new PetType { Name = "Turtle" },
                new PetType { Name = "Frog" },
                new PetType { Name = "Bird" },
                new PetType { Name = "Snake" },
                new PetType { Name = "Ponny" },
                new PetType { Name = "Donkey" },
                new PetType { Name = "Horse" },
                new PetType { Name = "Sheep" },
                new PetType { Name = "Cow" },
                new PetType { Name = "Chicken" },
                new PetType { Name = "Platypus" },
                new PetType { Name = "Mongoose" },
                new PetType { Name = "Monkey" },
                new PetType { Name = "Other..." }
                );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        private void SeedAdminUser(PetAdoptDbContext context)
        {
            // Access the application context and create result variables.
            IdentityResult IdRoleResult;
            IdentityResult IdUserResult;

            var roleStore = new RoleStore<IdentityRole>(context);

            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            if (!roleMgr.RoleExists("admin"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole { Name = "admin" });
            }

            var userMgr = new UserManager<User>(new UserStore<User>(context));

            var appUser = new User
            {
                UserName = "admin@admin.admin",
                Email = "admin@admin.admin",
                FirstName = "Admin",
                LastName = "Adminov"
            };

            IdUserResult = userMgr.Create(appUser, "administrator");

            if (!userMgr.IsInRole(userMgr.FindByEmail("admin@admin.admin").Id, "admin"))
            {
                IdUserResult = userMgr.AddToRole(userMgr.FindByEmail("admin@admin.admin").Id, "admin");
            }
        }
    }
}
