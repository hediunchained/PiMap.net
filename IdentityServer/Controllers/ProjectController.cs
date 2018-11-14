using Domain.Entity;
using IdentityServer.Models;
using ServiceSpecifiques;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IdentityServer.Controllers
{
    public class ProjectController : Controller
    {

        ProjectService serviceProject = null;

        public ProjectController()
        {
            serviceProject = new ProjectService();
        }

        // GET: Project
        public ActionResult Index()
        {
            var Project = serviceProject.GetAll();
            List<Projet> fVM = new List<Projet>();
            foreach (var item in Project)
            {
                fVM.Add(new Projet
                {
                    Name = item.Name,
                    Start_Date = item.Start_Date,
                    End_Date = item.End_Date,
                    Adresse = item.Adresse,
                    Total_Ressource_nb = item.Total_Ressource_nb,
                    Levio_ressource_nb = item.Levio_ressource_nb,
                    PictureURL = item.PictureURL,
                    ClientId = item.ClientId,
                    ProjetID = item.ProjetID

                });
            }
            return View(fVM);
        }

        // GET: Project/Details/5
        [HttpPost]
        public ActionResult Index(string searchString)
        {
            var Project = serviceProject.GetAll();
            List<Projet> fVM = new List<Projet>();
            foreach (var item in Project)
            {
                fVM.Add(new Projet
                {
                    Name = item.Name,
                    Start_Date = item.Start_Date,
                    End_Date = item.End_Date,
                    Adresse = item.Adresse,
                    Total_Ressource_nb = item.Total_Ressource_nb,
                    Levio_ressource_nb = item.Levio_ressource_nb,
                    PictureURL = item.PictureURL,
                    ClientId = item.ClientId,
                    ProjetID = item.ProjetID

                });
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                fVM = fVM.Where(m => m.Name.Contains(searchString)).ToList();
            }

            return View(fVM);
        }

     

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(Project MapProject, HttpPostedFileBase Picture)
        {
            Projet project = new Projet();

            project.Name = MapProject.Name;
            project.Start_Date = MapProject.Start_Date;
            project.End_Date = MapProject.End_Date;
            project.Adresse = MapProject.Adresse;
            project.Total_Ressource_nb = MapProject.Total_Ressource_nb;
            project.Levio_ressource_nb = MapProject.Levio_ressource_nb;
            project.PictureURL = MapProject.PictureURL;
            project.PictureURL = Picture.FileName;
            project.ClientId = MapProject.ClientId;


            serviceProject.Add(project);
            serviceProject.Commit();
            
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Picture.FileName);
            Picture.SaveAs(path);
            return RedirectToAction("Index");

        }

        // GET: Project/Edit/5
        public ActionResult Edit(int id,HttpPostedFileBase Picture)
        {
            Projet p = serviceProject.GetById(id);
            Projet projet = new Projet
            {
               Name = p.Name,
               Start_Date = p.Start_Date,
               End_Date = p.End_Date,
               Adresse = p.Adresse,
               Total_Ressource_nb = p.Total_Ressource_nb,
               Levio_ressource_nb = p.Levio_ressource_nb,
               PictureURL = p.PictureURL,
               //PictureURL = p.FileName,
              ClientId = p.ClientId
        };
            return View(projet);
        }

        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Projet MapProject , HttpPostedFileBase Picture)
        {
            Projet project = serviceProject.GetById(id);
            project.Name = MapProject.Name;
            project.Start_Date = MapProject.Start_Date;
            project.End_Date = MapProject.End_Date;
            project.Adresse = MapProject.Adresse;
            project.Total_Ressource_nb = MapProject.Total_Ressource_nb;
            project.Levio_ressource_nb = MapProject.Levio_ressource_nb;
            project.PictureURL = MapProject.PictureURL;
            project.PictureURL = Picture.FileName;
            project.ClientId = MapProject.ClientId;


            serviceProject.Update(project);
            serviceProject.Commit();

            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Picture.FileName);
            Picture.SaveAs(path);
            return RedirectToAction("Index");
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Project/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Projet projet = serviceProject.GetById(id);

                serviceProject.Delete(projet);
                serviceProject.Commit();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { ProjetID = id, saveChangesError = true });
            }

            return RedirectToAction("index");

        }

        //[HttpGet]
        //public PartialViewResult GetDeletePartial(int id)
        //{
        //    var deleteItem = serviceProject.GetById(id);  // I'm using 'Items' as a generic term for whatever item you have

        //    return PartialView("Delete", deleteItem);  // assumes your delete view is named "Delete"
        //}

    }
}
