using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdentityServer.Models
{
    public class Project
    {
        [Key]
        public int ProjetID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime Start_Date { get; set; }
        [DataType(DataType.Date)]
        public DateTime End_Date { get; set; }
        public string Adresse { get; set; }
        public int Total_Ressource_nb { get; set; }
        public int Levio_ressource_nb { get; set; }
        [DataType(DataType.ImageUrl), Display(Name = "Picture")]
        public string PictureURL { get; set; }
        [ForeignKey("Client")]
        public int? ClientId { get; set; }
        public virtual Client Client { get; set; }
        virtual public ICollection<Mandate> Mandates { get; set; }
        virtual public ICollection<Ressource> Ressources { get; set; }
        //public virtual Organizational_chart Organizational_chart { get; set; }
    }
}