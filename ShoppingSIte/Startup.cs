using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ShoppingSite.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using ShoppingSIte.Models;

[assembly: OwinStartupAttribute(typeof(ShoppingSite.Startup))]
namespace ShoppingSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            new UserRoles().CreateRolesandUsers();

        }
        

            }
        }
