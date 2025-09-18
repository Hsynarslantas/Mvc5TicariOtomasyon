using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommercialAutomation.Models.Classes;

namespace CommercialAutomation.Controllers
{
    public class SalesController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            var value = context.SalesTransactions.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CreateSale()
        {
            List<SelectListItem> deger1 = (from x in context.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName+" "+ x.CurrentSurname,
                                               Value = x.CurrentId.ToString()
                                           }).ToList();
            ViewBag.currents = deger1;
            List<SelectListItem> deger2 = (from x in context.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.EmployeeId.ToString()
                                           }).ToList();
            ViewBag.employees = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult CreateSale(SalesTransaction salesTransaction)
        {
            context.SalesTransactions.Add(salesTransaction);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSale(int id)
        {
            var value = context.SalesTransactions.Find(id);
            context.SalesTransactions.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetSale(int id)
        {
            List<SelectListItem> deger1 = (from x in context.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName + " " + x.CurrentSurname,
                                               Value = x.CurrentId.ToString()
                                           }).ToList();
            ViewBag.currents = deger1;
            List<SelectListItem> deger2 = (from x in context.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.EmployeeId.ToString()
                                           }).ToList();
            ViewBag.employees = deger2;
            var value = context.SalesTransactions.Find(id);
            return View("GetSale", value);
        }
        public ActionResult UpdateSale(SalesTransaction salesTransaction)
        {
            var value = context.SalesTransactions.Find(salesTransaction.SalesTransactionId);
            value.Date = salesTransaction.Date;
            value.Count = salesTransaction.Count;
            value.Price = salesTransaction.Price;
            value.TotalPrice = salesTransaction.TotalPrice;
            value.CurrentId = salesTransaction.CurrentId;
            value.EmployeeId = salesTransaction.EmployeeId; 
            value.ProductId = salesTransaction.ProductId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SaleDetail(int id)
        {
            var values=context.SalesTransactions.Where(x=>x.SalesTransactionId == id).ToList();
            return View(values);
        }
    }
}