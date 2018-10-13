using System;
using System.Collections.Generic;
using System.Linq;
using EasyHealth.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(EasyHealth.Startup))]

namespace EasyHealth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }


        public void CreateRolesandUsers()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(
                   new RoleStore<IdentityRole>(db)
                   );

            if (!roleManager.RoleExists("Admin"))
            {
                var resultado = roleManager.Create(new IdentityRole("Admin"));
            }
            if (!roleManager.RoleExists("Medico"))
            {
                var resultado = roleManager.Create(new IdentityRole("Medico"));
            }
            if (!roleManager.RoleExists("Afiliado"))
            {
                var resultado = roleManager.Create(new IdentityRole("Afiliado"));
            }

            //using (ApplicationDbContext dbs = new ApplicationDbContext())
            //{

            //    var UserManager = new UserManager<ApplicationUser>(
            //        new UserStore<ApplicationUser>(dbs));

            //    var user = new ApplicationUser()
            //    {
            //        Email = "a@a.a",
            //        UserName = "a@a.a"
            //    };
            //    var resultado = UserManager.Create(user, "Cisco123.");
            //    var result1 = UserManager.AddToRole(user.Id, "Admin");
            //}
        }
    }
}
