using Domain.Entity;
using IdentityServer.Models;
using ServiceSpecifiques;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sina.Trainings.AECustomIdentity.Controllers
{
    public class HomeController : Controller
    {
        ProjectService serviceProject = null;

        public HomeController()
        {
            serviceProject = new ProjectService();
        }
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Client")]
        public ActionResult IndexClient()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult IndexAdmin()
        {
            return View();
        }
        [Authorize(Roles = "Manager")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page. It will show to only authorized People";

            return View();
        }

        [HttpPost]
        public ActionResult Create()
        {

            return View();
        }
    }
}