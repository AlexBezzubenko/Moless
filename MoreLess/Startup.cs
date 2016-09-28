using Microsoft.Owin;
using Owin;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MoreLess.Models;
using System.Data.Entity;
using System.Linq;

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

            Category category1 = new Category();
            Category category2 = new Category();
            Category category3 = new Category();
            category1.Title = "SomeCat";
            category2.Title = "someSubCat1";
            category3.Title = "someSubCat2";

            context.Categories.Add(category1);
            context.Categories.Add(category2);
            context.Categories.Add(category3);


            category1.Subcategories.Add(category2);
            category1.Subcategories.Add(category3);


            context.SaveChanges();

        }
    }
}
