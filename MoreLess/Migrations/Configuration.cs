namespace MoreLess.Migrations
{
   
    using System.Data.Entity.Migrations;
 
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using MoreLess.Models;


    internal sealed class Configuration : DbMigrationsConfiguration<MoreLess.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MoreLess.Models.ApplicationDbContext context)
        {
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

            //context.Roles.Add(new IdentityRole { Name = "admin" });
            //context.SaveChanges();

            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // ������� ��� ����
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };

            // ��������� ���� � ��
            roleManager.Create(role1);
            roleManager.Create(role2);

            // ������� �������������
            var admin = new ApplicationUser { Email = "somemail@mail.ru", UserName = "somemail@mail.ru" };
            string password = "ad46D_ewr3";
            var result = userManager.Create(admin, password);

            // ���� �������� ������������ ������ �������
            if (result.Succeeded)
            {
                // ��������� ��� ������������ ����
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }

            base.Seed(context);
        }
    }
}
