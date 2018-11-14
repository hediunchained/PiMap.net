using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Domain.Entity
{
    public class Ressource : Users
    {
        public string ContractType { get; set; }
        public string Seniority { get; set; }
        public string SkillSet { get; set; }
        public string Holidays { get; set; }
        public string Notes { get; set; }
        public string Resume { get; set; }
        public string Current_mandate { get; set; }
        [DataType(DataType.ImageUrl), Display(Name = "Picture")]
        public string PictureURL { get; set; }
        public string Mandate_History { get; set; }
        public int Rate { get; set; }
        public string state { get; set; }
        //public virtual Application_Lettre Application_Lettre { get; set; }
        //public virtual Mandate Mandate { get; set; }
        //[ForeignKey("Organizational_chart")]
        //public int? OrganizationalId { get; set; }
        //public virtual Organizational_chart Organizational_chart { get; set; }
        //public int? ProjetID { get; set; }
        //[ForeignKey("ProjetID")]
        //public virtual Projet Projet { get; set; }

    }
}