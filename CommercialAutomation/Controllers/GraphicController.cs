using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using CommercialAutomation.Models.Classes;

namespace CommercialAutomation.Controllers
{
    public class GraphicController : Controller
    {
        Context context=new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var creategraphic = new Chart(600, 600);
            creategraphic.AddTitle("Kategori-Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler", xValue: new[] { "Beyaz Eşya", "Telefon", "Televizyon", "Küçük Ev Aletleri" }, yValues: new[] { "20", "20", "20", "20" }).Write();

            return File(creategraphic.ToWebImage().GetBytes(),"image/jpeg");
        }
        public ActionResult Index3()
        {
            ArrayList xvalue= new ArrayList();
            ArrayList yvalue= new ArrayList();
            var result=context.Products.ToList();
            result.ToList().ForEach(x =>xvalue.Add(x.ProductName));
            result.ToList().ForEach(y => yvalue.Add(y.ProductStock));
            var graphic = new Chart(600, 800).AddTitle("Stoklar").AddSeries(chartType: "Pie", name: "Stok", xValue: xvalue, yValues: yvalue);

            return File(graphic.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeProductResult()
        {
            return Json(ChartProductList(),JsonRequestBehavior.AllowGet);
        }
        public List<ChartClass> ChartProductList()
        {
           List<ChartClass> cls= new List<ChartClass>();
            cls.Add(new ChartClass()
            {
                ProductName = "Beyaz Eşya",
                Stok = 100
            });
            cls.Add(new ChartClass()
            {
                ProductName = "Telefon",
                Stok = 400
            });
            cls.Add(new ChartClass()
            {
                ProductName = "Küçük Ev Aletleri",
                Stok = 2000
            });
            cls.Add(new ChartClass()
            {
                ProductName = "Bilgisayar",
                Stok = 1000
            });
            cls.Add(new ChartClass()
            {
                ProductName = "Tablet",
                Stok = 50
            });
            return cls;
        }
        public ActionResult VisualizeProductResult2()
        {
            return Json(ChartProductList2(), JsonRequestBehavior.AllowGet);
        }
        public List<ChartClass2> ChartProductList2()
        {
            List<ChartClass2> cls2 = new List<ChartClass2>();
            using (var context=new Context())
            {
                cls2 = context.Products.Select(x => new ChartClass2
                {
                    Name=x.ProductName,
                    Stok=x.ProductStock
                }).ToList();
            }
            return cls2 ;
        }
        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }
    }
}