using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Application_Lettre
    {
        [Key]
        public int ApplicationID { get; set; }
        public string State { get; set; }
        public string Date { get; set; }
        public string Specialty { get; set; }
        public string Resume { get; set; }
        //public virtual Ressource Ressource { get; set; }
    }
}
