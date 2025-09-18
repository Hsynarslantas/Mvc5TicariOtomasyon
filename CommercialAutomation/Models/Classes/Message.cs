using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommercialAutomation.Models.Classes
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Sender { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Receive { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Title { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Subject { get; set; }
       
        public DateTime Date { get; set; }
    }
}