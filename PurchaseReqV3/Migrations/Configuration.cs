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
                new IdentityRole { Name = "Employee" },
                new IdentityRole { Name = "CFO" },
                new IdentityRole { Name = "President" },
                new IdentityRole { Name = "Student Dean"},
                new IdentityRole { Name = "Academic Division Chair" },
                new IdentityRole { Name = "Purchasing staff" },
                new IdentityRole { Name = "Academic Department Head" },
                new IdentityRole { Name = "Maintenance Division Head" },
                new IdentityRole { Name = "State Auditor" },
                new IdentityRole { Name = "Grounds Keeping Department Head" }
                );
            //ADDING ADMIN
            if (!context.Users.Any(u => u.UserName == "Admin@web.com"))
            {
                var admin = new User
                {
                    UserName = "Admin@web.com",
                    Email = "Admin@web.com",
                    F_name = "Bill",
                    L_name = "Admin",
                    Address = "address",
                  //PhoneNumber= "304-486-6654",
                    PasswordHash = PasswordHash.HashPassword("Admin!123"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };

                UserManager.Create(admin);
                UserManager.AddToRole(admin.Id, "Admin");
            }
            //Adding CFO
            if (!context.Users.Any(u => u.UserName == "Alice@web.com"))
            {
                var CFO = new User
                {
                    UserName = "Alice@web.com",
                    Email = "Alice@web.com",
                    F_name = "Alice",
                    L_name = "CFO",
                    Address = "address",
                    PasswordHash = PasswordHash.HashPassword("Alice!123"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };

                UserManager.Create(CFO);
                UserManager.AddToRole(CFO.Id, "CFO");
            }

             if (!context.Users.Any(u => u.UserName == "Cheri@web.com"))
            {
                var StateAuditor = new User
                {
                    UserName = "Cheri@web.com",
                    Email = "Cheri@web.com",
                    F_name = "Cheri",
                    L_name = "StateAuditor",
                    Address = "address",
                    PasswordHash = PasswordHash.HashPassword("Cheri!123"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };

                UserManager.Create(StateAuditor);
                UserManager.AddToRole(StateAuditor.Id, "State Auditor");
            }

            if (!context.Users.Any(u => u.UserName == "Steve@web.com"))
            {
                var Employee  = new User
                {
                    UserName = "Steve@web.com",
                    Email = "Steve@web.com",
                    F_name = "Steve",
                    L_name = "Employee",
                    Address = "address",
                    PasswordHash = PasswordHash.HashPassword("Steve!123"),
                    Active = true,
                    DateHired = new DateTime(2019,04,20)
                };

                UserManager.Create(Employee);
                UserManager.AddToRole(Employee.Id, "Employee");
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}