using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Request
    {
        [Key]
        public int RequestID { get; set; }
        [DataType(DataType.MultilineText)]
        public String Requirements { get; set; }
        public int YearsExperience { get; set; }
        public string Education { get; set; }
        public Projet Project { get; set; }
        public int Price { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Deposit_Date { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{H:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime Deposit_hour { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Mandatestart_date { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime MandateFinish_date { get; set; }
        public int ClientId { get; set; }
        //[ForeignKey("Id")]
        //public virtual Client Client { get; set; }


    }
}
