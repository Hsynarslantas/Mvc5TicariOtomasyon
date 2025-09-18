using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommercialAutomation.Models.Classes
{
    public class SalesTransaction
    {
        [Key]
        public int SalesTransactionId { get; set; }
        public  virtual Product Product { get; set; }
        public virtual Current Current { get; set; }
        public virtual Employee Employee { get; set; }
        public int ProductId { get; set; }
        public int CurrentId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}