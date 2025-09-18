using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommercialAutomation.Models.Classes;

namespace CommercialAutomation.Controllers
{
    public class GaleryController : Controller
    {
        Context context=new Context(); 
        public ActionResult Index()
        {
            var values=context.Products.ToList();
            return View(values);
        }
    }
}