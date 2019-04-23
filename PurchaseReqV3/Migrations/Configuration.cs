namespace PurchaseReqV3.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PurchaseReqV3.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PurchaseReqV3.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PurchaseReqV3.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<User>(new UserStore<User>(context));
            var PasswordHash = new PasswordHasher();
            context.Roles.AddOrUpdate(r => r.Id,
                new IdentityRole { Name = "Admin" },
                new IdentityRole {Name ="Employee" }
                );
            //ADDING ADMIN
            if (!context.Users.Any(u => u.UserName == "Admin@develop.com"))
            {
                var admin = new User
                {
                    UserName = "Admin@develop.com",
                    Email = "Admin@Develop.com",
                    F_name = "Admin",
                    L_name = "Admin",
                    Address = "address",
                    PasswordHash = PasswordHash.HashPassword("Admin1234!")
                };

                UserManager.Create(admin);
                UserManager.AddToRole(admin.Id, "Admin");
            }


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
