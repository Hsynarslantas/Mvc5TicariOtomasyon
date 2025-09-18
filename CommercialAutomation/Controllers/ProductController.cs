using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommercialAutomation.Models.Classes;

namespace CommercialAutomation.Controllers
{
    public class ProductController : Controller
    {
        Context context = new Context();

        public ActionResult Index(string p)
        {
            var value = from x in context.Products select x;
            if (!string.IsNullOrEmpty(p))
            {
                value=value.Where(y=>y.ProductName.Contains(p));
            }
            return View(value.ToList());
        }
        [HttpGet]
        public ActionResult CreateProduct()
        {
            List<SelectListItem> deger1 = (from x in context.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.CategoryId.ToString()
                                          }).ToList();
            ViewBag.categories= deger1;
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            product.Status = true;
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProduct(int id)
        {
            var value = context.Products.Find(id);
            context.Products.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetProduct(int id)
        {
            List<SelectListItem> deger1 = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.categories = deger1;
            var value = context.Products.Find(id);
            return View("GetProduct", value);
        }
        public ActionResult UpdateProduct(Product product)
        {
            var value = context.Products.Find(product.ProductId);
            value.ProductId = product.ProductId;
            value.ProductName = product.ProductName;
            value.ProductPurchasePrice = product.ProductPurchasePrice;
            value.ProductStock = product.ProductStock;
            value.ProductBrand = product.ProductBrand;
            value.ImageUrl = product.ImageUrl;
            value.ProductSalePrice= product.ProductSalePrice;
            value.Status = product.Status;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductList()
        {
            var values = context.Products.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult ProductSale(int id)
        {
            List<SelectListItem> deger1 = (from x in context.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.EmployeeId.ToString()
                                           }).ToList();
            ViewBag.e = deger1;
            var deger2 = context.Products.Find(id);
            ViewBag.v1 = deger2.ProductId;
            ViewBag.v2 = deger2.ProductSalePrice;
            return View();
        }
        [HttpPost]
        public ActionResult ProductSale(SalesTransaction s)
        {
            s.Date=DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SalesTransactions.Add(s);
            context.SaveChanges();
            return RedirectToAction("Index","Sales");
        }
    }
}