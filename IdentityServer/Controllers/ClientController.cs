using Domain.Entity;
using ServiceSpecifiques;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityServer.Controllers
{
    public class ClientController : Controller
    {

        ClientService serviceClient = null;

        public ClientController()
        {
            serviceClient = new ClientService();
        }
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            Client ClientModel = new Client();
            // dropdowlist de genre

            //List<string> ClientTypes = new List<string> { "Current_type", "New_Client", "Finished_Contract" };

            //ViewData["Type"] = new SelectList(ClientTypes);

            List<string> Categories = new List<string> { "Public", "Private" };

            ViewData["Category"] = new SelectList(Categories);



            return View();
        }

        [HttpPost]
        public ActionResult Create(Client MapClient, HttpPostedFileBase logo)
        {
            MapClient.logoURL = logo.FileName;
            //List<string> ClientTypes = new List<string> { "Current_type", "New_Client", "Finished_Contract" };

            //ViewData["Type"] = new SelectList(ClientTypes);

            //List<string> Categories = new List<string> { "Public", "Private" };

            //ViewData["Category"] = new SelectList(Categories);
            try
            {

                

                serviceClient.Add(MapClient);
                serviceClient.Commit();

                
            }
            catch (DbEntityValidationException dbEx)
            {
                var errorList = new List<string>();

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorList.Add(String.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage));
                    }
                }
                return Json(errorList);
            }
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), logo.FileName);
            logo.SaveAs(path);
            //return RedirectToAction("Index");
            return View();
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
