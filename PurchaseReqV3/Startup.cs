using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using PurchaseReqV3.Models;

[assembly: OwinStartupAttribute(typeof(PurchaseReqV3.Startup))]
namespace PurchaseReqV3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();

        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<User>(new UserStore<User>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            //if (!roleManager.RoleExists("Admin"))
            //{

            //    // first we create Admin rool   
            //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            //    role.Name = "Admin";
            //    roleManager.Create(role);

            //    //Here we create a Admin super user who will maintain the website                  

            //    var user = new User();
            //    user.UserName = "admin";
            //    user.Email = "admin@admin.com";

            //    string userPWD = "Admin!123";

            //    var chkUser = UserManager.Create(user, userPWD);

            //    //Add default User to Role Admin   
            //    if (chkUser.Succeeded)
            //    {
            //        var result1 = UserManager.AddToRole(user.Id, "Admin");

            //    }
            //}

            ////creating creating manager role
            //if (!rolemanager.roleexists("supervisor"))
            //{
            //    var role = new microsoft.aspnet.identity.entityframework.identityrole();
            //    role.name = "supervisor";
            //    rolemanager.create(role);

            //}

            ////creating creating employee role
            //if (!rolemanager.roleexists("employee"))
            //{
            //    var role = new microsoft.aspnet.identity.entityframework.identityrole();
            //    role.name = "employee";
            //    rolemanager.create(role);
            //}
        }
    }
}