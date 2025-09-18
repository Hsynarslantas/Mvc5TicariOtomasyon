using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommercialAutomation.Models.Classes
{
    public class InvoiceItem
    {
        [Key]
        public int InvoiceItemId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description { get; set; }
        public int  Count { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public  virtual Invoice Invoice { get; set; }
        public int InvoiceId { get; set; }

    }
}