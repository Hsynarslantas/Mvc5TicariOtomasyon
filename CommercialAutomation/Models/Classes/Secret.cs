using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommercialAutomation.Models.Classes
{
    public class Secret
    {
        public IEnumerable<Invoice> sub1 { get; set; }
        public IEnumerable<InvoiceItem> sub2 { get; set; }
    }
}