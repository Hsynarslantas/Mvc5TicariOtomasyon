using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommercialAutomation.Models.Classes
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string InvoiceSerialNumber { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string InvoiceOrderNumber { get; set; }
        public DateTime Date { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaxOffice { get; set; }
        public DateTime Hour { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Delivered { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Received { get; set; }
        public decimal Total { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}