using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CommercialAutomation.Models.Classes;

namespace CommercialAutomation.Controllers
{
    public class CurrentPanelController : Controller
    {
        
        Context context =new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CurrentMail"];
            var result = context.Messages.Where(x => x.Receive == mail).ToList();
            ViewBag.m=mail;
            var mailid=context.Currents.Where(x=>x.CurrentMail==mail).Select(y=>y.CurrentId).FirstOrDefault();
            ViewBag.mid=mailid;
            var totalsales=context.SalesTransactions.Where(x=>x.CurrentId==mailid).Count();
            ViewBag.ts=totalsales;
            var totalprice = context.SalesTransactions.Where(x => x.CurrentId == mailid).Sum(y => y.TotalPrice);
            ViewBag.tp=totalprice;
            var totalproductcount = context.SalesTransactions.Where(x => x.CurrentId == mailid).Sum(y => y.Count);
            ViewBag.tpc=totalproductcount;
            var  namesurname=context.Currents.Where(x=>x.CurrentMail==mail).Select(y=>y.CurrentName+" "+ y.CurrentSurname).FirstOrDefault();
            ViewBag.nmsrnm=namesurname;
            return View(result);
        }
        [Authorize]
        public ActionResult Orders()
        {
            var mail = (string)Session["CurrentMail"];
            var id=context.Currents.Where(x=>x.CurrentMail==mail.ToString()).Select(y=>y.CurrentId).FirstOrDefault();
            var values=context.SalesTransactions.Where(x=>x.CurrentId==id).ToList();
            return View(values);
        }
        [Authorize]
        public ActionResult IncomingMessage()
        {
            var mail = (string)Session["CurrentMail"];
            var values=context.Messages.Where(x=>x.Receive==mail).OrderByDescending(y=>y.MessageId).ToList();
            var count=context.Messages.Count(x=>x.Receive==mail).ToString();
            var send = context.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.s = send;
            ViewBag.c=count;
            return View(values);
        }
        [Authorize]
        public ActionResult SentMessage()
        {
            var mail = (string)Session["CurrentMail"];
            var values = context.Messages.Where(x => x.Sender == mail).OrderByDescending(y => y.MessageId).ToList();
            var send = context.Messages.Count(x => x.Sender == mail).ToString();
            var count = context.Messages.Count(x => x.Receive == mail).ToString();
            ViewBag.s = send;
            ViewBag.c = count;
            return View(values);
        }
        [Authorize]
        [HttpGet]
        public ActionResult CreateMessage()
        {
            var mail = (string)Session["CurrentMail"];
            var values = context.Messages.Where(x => x.Sender == mail).ToList();
            var send = context.Messages.Count(x => x.Sender == mail).ToString();
            var count = context.Messages.Count(x => x.Receive == mail).ToString();
            ViewBag.s = send;
            ViewBag.c = count;
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult CreateMessage(Message message)
        {
            var mail = (string)Session["CurrentMail"];
            message.Date = DateTime.Now;
            message.Sender = mail;
            context.Messages.Add(message);
            context.SaveChanges();
            return View();
        }
        [Authorize]
        public ActionResult MessageDetail(int id)
        {
            var value = context.Messages.Where(x => x.MessageId == id).ToList();
            var mail = (string)Session["CurrentMail"];
            var send = context.Messages.Count(x => x.Sender == mail).ToString();
            var count = context.Messages.Count(x => x.Receive == mail).ToString();
            ViewBag.s = send;
            ViewBag.c = count;
            return View(value);
        }
        [Authorize]
        public ActionResult CargoTrack(string c)
        {
            var value = from x in context.CargoDetails select x;
            if (!string.IsNullOrEmpty(c))
            {
                value = value.Where(y => y.Description.Contains(c));
            }
            return View(value.ToList());
        }
        [Authorize]
        public ActionResult CurrentCargoDetail(string id)
        {
            var value = context.CargoTrackings.Where(x => x.CargoTrackingCode == id).ToList();
            return View(value);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
        public PartialViewResult Partial1()
        {
            var mail = (string)Session["CurrentMail"];
            var id=context.Currents.Where(x=>x.CurrentMail==mail).Select(y=>y.CurrentId).FirstOrDefault();
            var findcurrent = context.Currents.Find(id);
            
            return PartialView("Partial1", findcurrent);
        }
        public PartialViewResult Partial2()
        {
            var veriler = context.Messages.Where(x => x.Sender == "Admin").ToList();
            return PartialView(veriler);
        }
        public ActionResult CurrentInfoUpdate(Current c)
        {
            c.Status=true;
            var current = context.Currents.Find(c.CurrentId);
            current.CurrentName = c.CurrentName;
            current.CurrentMail = c.CurrentMail;
            current.CurrentSurname = c.CurrentSurname;
            current.CurrentCity = c.CurrentCity;
            current.CurrentTitle = c.CurrentTitle;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}