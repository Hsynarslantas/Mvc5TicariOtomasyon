using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommercialAutomation.Models.Classes;

namespace CommercialAutomation.Controllers
{
    public class StatisticController : Controller
    {
       Context context=new Context();
        public ActionResult Index()
        {
            var values=context.Currents.Count().ToString();
            ViewBag.d1=values;
            var values1 = context.Products.Count().ToString();
            ViewBag.d2= values1;
            var values2 = context.Employees.Count().ToString();
            ViewBag.d3 = values2;
            var values3 = context.Categories.Count().ToString();
            ViewBag.d4 = values3;
            var values4 = context.Products.Sum(x=>x.ProductStock).ToString();
            ViewBag.d5 = values4;
            var values5 = context.Products.Select(x=>x.ProductBrand).Count().ToString();
            ViewBag.d6 = values5;
            var values6 = context.Products.Count(x=>x.ProductStock<=20).ToString();
            ViewBag.d7 = values6;
            var values7 = context.Products.Max(x=>x.ProductSalePrice).ToString();
            ViewBag.d8 = values7;
            var values8 = context.Products.Min(x => x.ProductSalePrice).ToString();
            ViewBag.d9 = values8;
            var values9 = context.Products.GroupBy(x => x.ProductBrand).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            ViewBag.d10 = values9;
            var values10 = context.Products.Count(x => x.ProductStock >= 21 && x.ProductStock<=30).ToString();
            ViewBag.d11 = values10;
            var values11 = context.Products.Count(x => x.ProductStock >= 40).ToString();
            ViewBag.d12 = values11;
            var values12 = context.Products.Where(p=>p.ProductId==(context.SalesTransactions.GroupBy(x => x.ProductId).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault())).Select(k=>k.ProductName).FirstOrDefault();
            ViewBag.d13 = values12;
            DateTime bugun = DateTime.Today;
            var values13 = context.SalesTransactions.Count(x => x.Date==bugun).ToString();
            ViewBag.d14 = values13;
            var values14 = context.SalesTransactions.Where(x=>x.Date==bugun).Sum(y=>y.Count).ToString();
            ViewBag.d15 = values14;
            var values15 = context.SalesTransactions.Where(x => x.Date == bugun).Sum(y =>(decimal?) y.TotalPrice).ToString();
            ViewBag.d16= values15;
            return View();
        }
        public ActionResult EasyTable()
        {
            var values=from x in context.Currents group x by x.CurrentCity into g
                       select new ClassGroup
                       {
                           City=g.Key,
                           Number=g.Count(),
                       };
            return View(values.ToList());
        }
        public PartialViewResult Partial1()
        {
            var values2 = from x in context.Employees.Take(6)
                         group x by x.Department.DepartmentName into g
                         select new ClassGroup2
                         {
                             Department = g.Key,
                             Number = g.Count(),
                         };
            return PartialView(values2);
        }
        public PartialViewResult Partial2()
        {
           var values3=context.Currents.ToList();
            return PartialView(values3);
        }
        public PartialViewResult Partial3()
        {
            var values4 = context.Products.OrderByDescending(x=>x.ProductId).Take(5).ToList();
            return PartialView(values4);
        }
        public PartialViewResult Partial4()
        {
            var values5 = from x in context.Products.Take(5)
                          group x by x.ProductBrand into g
                          select new ClassGroup3
                          {
                              Brand = g.Key,
                              Number = g.Count(),
                          };
            return PartialView(values5);
        }

    }
    
}