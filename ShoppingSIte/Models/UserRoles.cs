using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ShoppingSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSIte.Models
{
    public class UserRoles
    {
        private ApplicationDbContext _userscontext = new ApplicationDbContext();

        public UserManager<ApplicationUser> GetUserManager()
        {
            var userStore = new UserStore<ApplicationUser>(_userscontext);
            return new UserManager<ApplicationUser>(userStore);
        }
        public RoleManager<IdentityRole> GetRoleManager()
        {
            return new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_userscontext));
        }
        public bool CheckUserInRole(string UserId,string role)
        {           

            if (GetUserManager().IsInRole(UserId, role))
            {
                return true;
            }
            return false;
        }
        public void CreateRolesandUsers()
        {
            string []roles = new string[]{ "Admin", "Customer" };

            foreach(string roleName in roles)
            {
                if (!GetRoleManager().RoleExists(roleName)){
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = roleName;
                    GetRoleManager().Create(role);
                }

            }
           
        }
    }
}