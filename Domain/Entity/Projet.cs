using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Projet
    {
        [Key]
        public int ProjetID { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required]
        public DateTime Start_Date { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required]
        public DateTime End_Date { get; set; }
        [Required]
        public string Adresse { get; set; }
        [Required]
        public int Total_Ressource_nb { get; set; }
        [Required]
        public int Levio_ressource_nb { get; set; }
        [DataType(DataType.ImageUrl), Display(Name = "Picture")]
        public string PictureURL { get; set; }
        //[ForeignKey("Client")]
        public int? ClientId { get; set; }
   
        //public virtual Client Client { get; set; }
        //virtual public ICollection<Mandate> Mandates { get; set; }
        //virtual public ICollection<Ressource> Ressources { get; set; }
        ////public virtual Organizational_chart Organizational_chart { get; set; }

    }
}
