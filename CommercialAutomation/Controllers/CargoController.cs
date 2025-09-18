using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommercialAutomation.Models.Classes;

namespace CommercialAutomation.Controllers
{
    public class CargoController : Controller
    {
        Context context = new Context();
        public ActionResult Index(string c)
        {
            var value = from x in context.CargoDetails select x;
            if (!string.IsNullOrEmpty(c))
            {
                value = value.Where(y => y.Description.Contains(c));
            }
            return View(value.ToList());
        }
        [HttpGet]
        public ActionResult CreateCargo()
        {
            Random random= new Random();
            string[] karakter = { "A","B","C","D" };
            int k1, k2, k3;
            k1 = random.Next(0, 4);
            k2 = random.Next(0, 4);
            k3 = random.Next(0, 4);
            int s1,s2,s3;
            s1= random.Next(110, 1000);
            s2 = random.Next(10, 99);
            s3 = random.Next(10, 99);
            string code = s1.ToString() + karakter[k1] + s2 + karakter[k2] + s3 + karakter[k3];
            ViewBag.cargocode = code;
            return View();
        }
        [HttpPost]
        public ActionResult CreateCargo(CargoDetail cargoDetail)
        {
            cargoDetail.Date= DateTime.Now;
            context.CargoDetails.Add(cargoDetail);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CargoDetail(string id)
        {
            var value = context.CargoTrackings.Where(x => x.CargoTrackingCode == id).ToList();
            return View(value);
        }
    }
}