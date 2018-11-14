using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Models
{
    public class Ressource:Users
    {
        [Key]
        public int RessourceID { get; set; }
  
        public String ContractType { get; set; }
        public string Seniority { get; set; }
        public string SkillSet { get; set; }
        public string Notes { get; set; }
        [DataType(DataType.Upload), Display(Name = "CV")]
        public string Resume { get; set; }
        [DataType(DataType.ImageUrl), Display(Name = "Picture")]
        public string PictureURL { get; set; }
        public String state { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "StartHoliday ")]
        public DateTime StartHoliday { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "EndHoliday")]
        public DateTime EndHoliday { get; set; }

        //public string Holidays { get; set; }

        //public string Current_mandate { get; set; }

        //public int Rate { get; set; }

        //public virtual Application_Lettre Application_Lettre { get; set; }
        //[ForeignKey("Mandate")]
        //public int? MandateID { get; set; }
        //public string Mandate_History { get; set; }

        //public virtual Mandate Mandate { get; set; }
        //public virtual Message Message { get; set; }
        [ForeignKey("Organizational_chart")]
        public int? OrganizationalId { get; set; }
        public virtual Organizational_chart Organizational_chart { get; set; }

        virtual public ICollection<Organizational_chart> Organizational_charts { get; set; }
        public IEnumerable<SelectListItem> Organizationals { get; set; }



        //[ForeignKey("Projet")]
        // public int? ProjetID { get; set; }
        //public virtual Projet Projet { get; set; }*

    }
}