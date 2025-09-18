using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommercialAutomation.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }
        public short ProductStock { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ProductBrand { get; set; }
        public decimal ProductPurchasePrice { get; set; }
        public decimal ProductSalePrice { get; set; }
        public bool Status { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(1000)]
        public string ImageUrl { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }

        public ICollection<SalesTransaction> SalesTransactions { get; set; }
    }
}