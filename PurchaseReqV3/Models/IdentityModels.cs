﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PurchaseReqV3.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
       // public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
       // {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
           // var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
          //  return userIdentity;
        //}
    }


    public class ApplicationDbContext : IdentityDbContext<IdentityUser>//possibly change to our user class
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }   

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Budget> Budget { get; set; }
        public DbSet<UserBudgetCode> UserBudgetCode { get; set; }
        public DbSet<Campus> Campus { get; set; }
        public DbSet<College> College { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Division> Division { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<JobRole> JobRole { get; set; }
        public DbSet<PurchaseRequisition> PurchaseRequisition { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Approval> Approval { get; set; }

        //public System.Data.Entity.DbSet<PurchaseReqV3.Models.Approval> Approvals { get; set; }

        // public System.Data.Entity.DbSet<PurchaseReqV3.Models.Address> Addresses { get; set; }

        //public System.Data.Entity.DbSet<PurchaseReqV3.Models.UserBudgetCode> UserBudgetCodes { get; set; }
    }
}