using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommercialAutomation.Models.Classes
{
    public class CargoDetail
    {
        [Key]
        public int CargoDetailId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string CargoCode { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Personel { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Buyer { get; set; }
        public DateTime Date { get; set; }
    }
}