using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using IdentityServer.Models;
using Domain.Entity;
using Data;

namespace TestIdentity
{
   
    [Authorize(Roles = "SuperAdmin")]
    public class AdminController : Controller
    {
        MAPContext context = new MAPContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateUser()
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(FormCollection form)
        {
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
            string UserName = form["txtEmail"];
            string email = form["txtEmail"];
            string pwd = form["txtPassword"];
            //create default user
            var user = new ApplicationUser();
            user.UserName = UserName;
            user.Email = email;

            var newuser = userManager.Create(user, pwd);
            if (newuser.Succeeded)
            {
                userManager.AddToRole(user.Id, "Client");
            }
            return View();
        }
        public ActionResult CreateRole()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult NewRole(FormCollection form)
        //{
        //    string rolename = form["RoleName"];
        //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        //    if (!roleManager.RoleExists(rolename))
        //    {
        //        //create super admin role
        //        var role = new IdentityRole(rolename);
        //        roleManager.Create(role);
        //    }
        //    return View("Index");
        //}

        public ActionResult AssignRole()
        {
            //ViewBag.Roles = context.Roles.Select(r => new SelectListItem { Value = r.Name.ToString(), Text = r.Name.ToString() }).ToList();
            return View();
        }
        //[HttpPost]
        ////public ActionResult AssignRole(FormCollection form)
        ////{
        ////    string usrname = form["txtUserName"];
        ////    string rolname = form["RoleName"];
        ////    IdentityUser user = context.Users.Where(u => u.UserName.Equals(usrname, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
        ////    var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
        ////    userManager.AddToRole(user.Id, rolname);


        ////    return View("Index");


        //}
    }
}