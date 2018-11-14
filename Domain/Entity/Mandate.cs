using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Mandate
    {
        [Key]
        public int MandateID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime MandateStart_Date { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime MandateFinish_Date { get; set; }
        public string State { get; set; }
        public int? ProjetID { get; set; }
        [ForeignKey("ProjetID")]
        public virtual Projet Projet { get; set; }
        public int RessourceId { get; set; }

    }
}
