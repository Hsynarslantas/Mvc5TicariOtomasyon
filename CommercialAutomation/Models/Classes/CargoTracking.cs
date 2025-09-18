using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommercialAutomation.Models.Classes
{
    public class CargoTracking
    {
        [Key]
        public int CargoTrackingId  { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string CargoTrackingCode { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}