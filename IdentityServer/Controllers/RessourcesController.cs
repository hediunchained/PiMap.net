using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.IO;
using Data;
using ServiceSpecifiques;
using IdentityServer.Models;
using System.Web.Mvc;
using Models;
using System.Data.Entity.Infrastructure;
using static IdentityServer.Models.ApplicationUser;

namespace IdentityServer.Controllers
{
    public class RessourcesController : Controller
    {
        RessourceService serviceRessource = null;
        OrganizationalService serviceOrganization = null;
        public RessourcesController()
        {

            serviceRessource = new RessourceService();
            serviceOrganization = new OrganizationalService();

        }

        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ressources
        public ActionResult Index()
        {

            var ress = serviceRessource.GetAll();

            List<Ressource> mvp = new List<Ressource>();
            foreach (var item in ress)
            {

                mvp.Add(
                    new Ressource
                    {
                        LastName = item.LastName,
                        FirstName = item.FirstName,
                        ContractType = item.ContractType,
                        Seniority = item.Seniority,
                        PictureURL = item.PictureURL,
                        SkillSet = item.SkillSet,
                        Notes = item.Notes,
                        Resume = item.Resume,
                        state = item.state,
                        OrganizationalId = item.OrganizationalId

                    });
            }
            return View(mvp);
        }

        // GET: Ressources/Details/5
        /*  public ActionResult Details(int? id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              Ressource ressource = db.Ressources.Find(id);
              if (ressource == null)
              {
                  return HttpNotFound();
              }
              return View(ressource);
          }*/

        // GET: Ressources/Create
        public ActionResult Create()
        {
            /*var ressource = new Ressource();
            ressource.Organizationals = serviceOrganization.GetAll().ToSelectListItems();
            return View(ressource);*/
            Ressource ress = new Ressource();

            var prod = serviceOrganization.GetAll();
            ViewData["Produc"] = new SelectList(prod, "OrganizationalId", "Nom");
            // ViewBag.Producteur = new SelectList(prod, "ProducteurId", "Nom");

            var x = serviceOrganization.GetAll().
               Select(w => new SelectListItem
               {
                   Text = w.Project_Name,
                   Value = w.OrganizationalId.ToString()
               });
            ress.Organizationals = x;
            return View(ress);

        }

        // POST: Ressources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase ImageId,/*[Bind(Include = "RessourceID,ContractType,Seniority,SkillSet,Notes,Resume,PictureURL,state")]*/ Ressource ressource)
        {

            /*  if (!ModelState.IsValid || ImageId == null || ImageId.ContentLength == 0)
              {
                  RedirectToAction("Create");
              }
              ressource.PictureURL = ImageId.FileName;
              TempData["Image"] = ImageId;
              Session["Ressource"] = ressource;

            //  db.Ressources.Add(ressource);
              db.SaveChanges();


                var image = TempData["Image"] as HttpPostedFileBase;

              var path = Path.Combine(Server.MapPath("~/Content/Upload/"), image.FileName);
                image.SaveAs(path);
               return RedirectToAction("Index");*/


            // Ressource R = new Ressource();

            Domain.Entity.Ressource ress = new Domain.Entity.Ressource();
            ress.LastName = ressource.LastName;
            ress.FirstName = ressource.FirstName;
            ress.ContractType = ressource.ContractType;
            ress.Seniority = ressource.Seniority;
            ress.PictureURL = ressource.PictureURL;
            ress.SkillSet = ressource.SkillSet;
            ress.Notes = ressource.Notes;
            ress.Resume = ressource.Resume;
            ress.state = ressource.state;
            ress.StartHoliday = ressource.StartHoliday;
            ress.EndHoliday = ressource.EndHoliday;
            ress.OrganizationalId = ressource.OrganizationalId;
            serviceRessource.Add(ress);
            serviceRessource.Commit();
            if (!ModelState.IsValid || ImageId == null || ImageId.ContentLength == 0)
            {
                RedirectToAction("Create");
            }
            ressource.PictureURL = ImageId.FileName;
            TempData["Image"] = ImageId;
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), ImageId.FileName);
            ImageId.SaveAs(path);
            return RedirectToAction("Index");


        }

        // GET: Ressources/Edit/5
        public ActionResult Edit(int id)
        {
            /* if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Domain.Entity.Ressource ressource = db.Ressources.Find(id);
             if (ressource == null)
             {
                 return HttpNotFound();
             }
             return View(ressource);*/
            return View();
        }

        // POST: Ressources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Ressource R, HttpPostedFileBase upload)
        {
            try
            {
                if (upload != null)
                {
                    string path = Path.Combine(Server.MapPath("~/Content/Upload"), upload.FileName);
                    upload.SaveAs(path);
                    R.PictureURL = upload.FileName;
                }
                Domain.Entity.Ressource ress = serviceRessource.GetById(id);
                ress.LastName = R.LastName;
                ress.FirstName = R.FirstName;
                ress.ContractType = R.ContractType;
                ress.Seniority = R.Seniority;
                ress.PictureURL = R.PictureURL;
                ress.SkillSet = R.SkillSet;
                ress.Notes = R.Notes;
                ress.Resume = R.Resume;
                ress.state = R.state;
                ress.OrganizationalId = R.OrganizationalId;
                serviceRessource.Update(ress);
                serviceRessource.Commit();
                return RedirectToAction("Index");

            } catch
            {
                return View();

            }
        }


        // GET: Ressources/Delete/5
        public ActionResult Delete(int id)
        {
            Domain.Entity.Ressource R = serviceRessource.GetById(id);
            Ressource ress = new Ressource();
            ress.LastName = R.LastName;
            ress.FirstName = R.FirstName;
            ress.ContractType = R.ContractType;
            ress.Seniority = R.Seniority;
            ress.PictureURL = R.PictureURL;
            ress.SkillSet = R.SkillSet;
            ress.Notes = R.Notes;
            ress.Resume = R.Resume;
            ress.state = R.state;
            ress.OrganizationalId = R.OrganizationalId;
            return View(ress);
        }

        //POST: Ressources/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            //try
            //{
            //    Domain.Entity.Ressource R = db.Ressources.Find(id);
            //    db.Ressources.Remove(R);
            //    db.SaveChanges();
            //}
            //catch (DataException/* dex */)
            //{
            //    //Log the error (uncomment dex variable name and add a line here to write a log.
            //    return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            //}
            //return RedirectToAction("Index");
            try
            {
                serviceRessource.Delete(serviceRessource.GetById(id));
                serviceRessource.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(id);
            }

        }

        //Get:Home
        public ActionResult IndexCalandar()
        {
            return View();
        }

        public JsonResult GetRessources()
        {
            using (MAPContext dc = new MAPContext())
            {
                var ressource = dc.Ressource.ToList();
                return new JsonResult { Data = ressource, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
