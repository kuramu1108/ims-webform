using System;
using IMSLogicLayer;
using Microsoft.Owin;
using Owin;
using InterventionManagementSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Data.SqlClient;

[assembly: OwinStartupAttribute(typeof(InterventionManagementSystem.Startup))]
namespace InterventionManagementSystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);

            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Setup DBsetup = new Setup(connstring);
            createUserAndRoles();
        }

        private void createUserAndRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            for (int i = 0; i < 10; i++)
            {
                var username = "User" + i;
                var user = new ApplicationUser()
                {
                    UserName = username,
                    Email = username + "@IMS.com"
                };

                var password = "Passw0rd@IMS.com";
                var result = userManager.Create(user, password);
                if (result.Succeeded)
                {
                    var currentUser = userManager.FindByName(username);
                    var roleResult = userManager.AddToRole(currentUser.Id, "SiteEngineer");
                    
                }
            }
            for (int i = 10; i < 20; i++)
            {
                var username = "User" + i;
                var user = new ApplicationUser()
                {
                    UserName = username,
                    Email = username + "@IMS.com"
                };

                var password = "Passw0rd@IMS.com";
                var result = userManager.Create(user, password);
                if (result.Succeeded)
                {
                    var currentUser = userManager.FindByName(username);
                    var roleResult = userManager.AddToRole(currentUser.Id, "Accountant");

                }
            }
            for (int i = 20; i < 30; i++)
            {
                var username = "User" + i;
                var user = new ApplicationUser()
                {
                    UserName = username,
                    Email = username + "@IMS.com"
                };

                var password = "Passw0rd@IMS.com";
                var result = userManager.Create(user, password);
                if (result.Succeeded)
                {
                    var currentUser = userManager.FindByName(username);
                    var roleResult = userManager.AddToRole(currentUser.Id, "Manager");

                }
            }
        }
    }
}
