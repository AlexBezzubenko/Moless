using Microsoft.Owin;
using Owin;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MoreLess.Models;

[assembly: OwinStartupAttribute(typeof(MoreLess.Startup))]
namespace MoreLess
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var context = new ApplicationDbContext();
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));


            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };

            if (!roleManager.RoleExists("admin")){
                roleManager.Create(role1);
            }
            if (!roleManager.RoleExists("user"))
            {
                roleManager.Create(role2);
            }

            var admin = new ApplicationUser { Email = "somemail2@gmail.ru", UserName = "somemail2@gmail.ru" };

            string password = "ad46D_ewr34";
            var result = userManager.Create(admin, password);

            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }
            

            context.SaveChanges();
            
        }
    }
}
