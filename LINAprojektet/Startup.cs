using LINAprojektet.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LINAprojektet.Startup))]
namespace LINAprojektet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRoles();
        }

        // Här skapas rollerna Admin och User
        private void createRoles()
        {
            using (var context = new ApplicationDbContext())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                
                if (!roleManager.RoleExists("Admin"))
                {
                    var role = new IdentityRole();
                    role.Name = "Admin";
                    roleManager.Create(role);
                }

                if (!roleManager.RoleExists("User"))
                {
                    var role = new IdentityRole();
                    role.Name = "User";
                    roleManager.Create(role);
                }
            }
        }
    }
}
