using Domain.Entity;
using ServiceSpecifiques;
using System;
using System.Collections.Generic;
using System.Data;
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
            var Client = serviceClient.GetAll();
            List<Client> fVM = new List<Client>();
            foreach (var item in Client)
            {
                fVM.Add(new Client
                {
                    UserName = item.UserName,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    ClientType = item.ClientType,
                    Category = item.Category,
                    logoURL = item.logoURL



                });
            }
            return View(fVM);
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {
            var Client = serviceClient.GetAll();
            List<Client> fVM = new List<Client>();
            foreach (var item in Client)
            {
                fVM.Add(new Client
                {
                    UserName=item.UserName,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    ClientType = item.ClientType,
                    Category = item.Category,
                    logoURL = item.logoURL



                });
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                fVM = fVM.Where(m => m.UserName.Contains(searchString)).ToList();
            }

            return View(fVM);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            Client ClientModel = new Client();
            // dropdowlist de genre

            //List<string> ClientTypes = new List<string> { "Current_type", "New_Client", "Finished_Contract" };

            //ViewData["Type"] = new SelectList(ClientTypes);

            //List<string> Categories = new List<string> { "Public", "Private" };

            //ViewData["Category"] = new SelectList(Categories);



            return View();
        }

        [HttpPost]
        public ActionResult Create(Client MapClient, HttpPostedFileBase logo)
        {
           
            try
            {
                Client client = new Client();

                MapClient.logoURL = logo.FileName;
                serviceClient.Add(client);
                serviceClient.Commit();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }


            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), logo.FileName);
            logo.SaveAs(path);
            //return RedirectToAction("Index");
            return RedirectToAction("Index");
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
            Client item = serviceClient.GetById(id);
            Client client = new Client
                {
                    UserName = item.UserName,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    ClientType = item.ClientType,
                    Category = item.Category,
                    logoURL = item.logoURL

                };
            
            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Client client = serviceClient.GetById(id);

                serviceClient.Delete(client);
                serviceClient.Commit();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { ProjetID = id, saveChangesError = true });
            }

            return RedirectToAction("index");
        }
    }
}
