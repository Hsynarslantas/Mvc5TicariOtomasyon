using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommercialAutomation.Models.Classes;

namespace CommercialAutomation.Controllers
{
    public class ProductDetailController : Controller
    {
        Context c =new Context();
        public ActionResult Index()
        {
            Class1 cs= new Class1();
            cs.Value1 = c.Products.Where(x => x.ProductId == 18).ToList();
            cs.Value2 = c.Details.Where(x => x.DetailId == 1).ToList();
            return View(cs);
        }
    }
}