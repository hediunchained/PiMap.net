using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Domain.Entity
{
    public class Client : Users
    {
   

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ClientId { get; set; }
        public string ClientType { get; set; }
        public string Category { get; set; }
        [DataType(DataType.ImageUrl), Display(Name = "logo")]
        public string logoURL { get; set; }
        //public virtual Message Message { get; set; }
        //virtual public ICollection<Request> Requests { get; set; }
        //virtual public ICollection<Projet> Projects { get; set; }
        //public virtual Organizational_chart Organizational_chart { get; set; }
    }

}