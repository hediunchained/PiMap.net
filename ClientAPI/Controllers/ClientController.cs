using ClientAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClientAPI.Controllers
{
    public class ClientController : ApiController
    {
        Client[] client = new Client[]
        {
            new Client { ClientId = 1,  ClientType= "Current_client", Category = "Private", FirstName = "ousssema" },
            new Client { ClientId = 2, ClientType = "Finished_Contact", Category = "public", FirstName = "yousri" },

        };

        public IEnumerable<Client> GetAllProducts()
        {
            return client;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var clients = client.FirstOrDefault((p) => p.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }
    }
}
