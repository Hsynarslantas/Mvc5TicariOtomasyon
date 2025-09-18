using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommercialAutomation.Models.Classes;

namespace CommercialAutomation.Controllers
{
    public class CurrentController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            var value = context.Currents.Where(x=>x.Status==true).ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CreateCurrent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCurrent(Current current)
        {
            current.Status = true;
            context.Currents.Add(current);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCurrent(int id)
        {
            var value = context.Currents.Find(id);
            context.Currents.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCurrent(int id)
        {
            var value = context.Currents.Find(id);
            return View("GetCurrent", value);
        }
        public ActionResult UpdateCurrent(Current current)
        {
            var value = context.Currents.Find(current.CurrentId);
            value.CurrentName = current.CurrentName;
            value.CurrentSurname = current.CurrentSurname;
            value.CurrentCity = current.CurrentCity;
            value.CurrentMail = current.CurrentMail;
            value.CurrentTitle = current.CurrentTitle;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CustomerSales(int id)
        {
            var values=context.SalesTransactions.Where(x=>x.CurrentId == id).ToList();
            var cr=context.Currents.Where(x=>x.CurrentId==id).Select(y=>y.CurrentName+" "+y.CurrentSurname).FirstOrDefault();
            ViewBag.employee = cr;
            return View(values);
        }
    }
}