using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Models
{
    public class Organizational_chart
    {
        [Key]       
        public int OrganizationalId { get; set; }
        public string Level { get; set; }
        public string Program_Name { get; set; }
        public string Leader_Name { get; set; }
        public string Project_Name { get; set; }
        public string Client_Name { get; set; }
        public string AccountManager { get; set; }
        public string Assignment_Manager_Name { get; set; }
        //public virtual Client Client { get; set; }


        //public virtual Projet Projet { get; set; }


    }
}
