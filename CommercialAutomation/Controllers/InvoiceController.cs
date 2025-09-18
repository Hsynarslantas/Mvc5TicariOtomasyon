using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommercialAutomation.Models.Classes;

namespace CommercialAutomation.Controllers
{
    public class InvoiceController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            var value = context.Invoices.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CreateInvoice()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateInvoice(Invoice invoice)
        {
            invoice.Date= DateTime.Today;
            invoice.Hour=DateTime.Now;
            context.Invoices.Add(invoice);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteInvoice(int id)
        {
            var value = context.Invoices.Find(id);
            context.Invoices.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetInvoice(int id)
        {
            var value = context.Invoices.Find(id);
            return View("GetInvoice", value);
        }
        public ActionResult UpdateInvoice(Invoice invoice)
        {
            var value = context.Invoices.Find(invoice.InvoiceId);
            value.InvoiceSerialNumber = invoice.InvoiceSerialNumber;
            value.InvoiceOrderNumber = invoice.InvoiceOrderNumber;
            value.TaxOffice=invoice.TaxOffice;
            invoice.Date = DateTime.Today;
            invoice.Hour = DateTime.Now;
            value.Delivered=invoice.Delivered;
            value.Received=invoice.Received;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult InvoiceDetail(int id)
        {
            var values = context.InvoiceItems.Where(x => x.InvoiceId == id).ToList();
            return View(values);  
        }
        [HttpGet]
        public ActionResult CreateInvoiceItem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateInvoiceItem(InvoiceItem invoiceitem)
        {
            context.InvoiceItems.Add(invoiceitem);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Dynamic()
        {
            Secret sc= new Secret();
            sc.sub1 = context.Invoices.ToList();
            sc.sub2 = context.InvoiceItems.ToList();
            return View(sc);
        }
        public ActionResult SaveInvoice(string FaturaSeriNo,string FaturaSıraNo,DateTime Tarih,string VergiDairesi,DateTime Saat,string TeslimEden,string TeslimAlan,string Toplam, InvoiceItem[] ınvoiceItems)
        {
            Invoice ınvoice = new Invoice();
            ınvoice.InvoiceSerialNumber=FaturaSeriNo;
            ınvoice.InvoiceOrderNumber = FaturaSıraNo;
            ınvoice.Date = Tarih;
            ınvoice.TaxOffice=VergiDairesi;
            ınvoice.Hour = Saat;
            ınvoice.Delivered = TeslimEden;
            ınvoice.Received = TeslimAlan;
            ınvoice.Total=decimal.Parse(Toplam);
            context.Invoices.Add(ınvoice);
            foreach(var x in ınvoiceItems)
            {
                InvoiceItem item = new InvoiceItem();
                item.Description=x.Description;
                item.Count=x.Count;
                item.UnitPrice=x.UnitPrice;
                item.TotalPrice=x.TotalPrice;
                item.InvoiceItemId=x.InvoiceItemId;
                context.InvoiceItems.Add(item);
            }
            return Json("İşlem Başarılı",JsonRequestBehavior.AllowGet);
        }
    }
}