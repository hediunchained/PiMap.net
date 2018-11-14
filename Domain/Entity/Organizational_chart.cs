using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
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
        //virtual public ICollection<Ressource> Ressources { get; set; }
        //public virtual Projet Projet { get; set; }


    }
}
