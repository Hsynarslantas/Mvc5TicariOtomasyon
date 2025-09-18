//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using CommercialAutomation.Models.Classes;

//namespace CommercialAutomation.Controllers
//{
//    public class MessageController : Controller
//    {
//        Context context = new Context();

//        public ActionResult Index()
//        {
//            var value = context.Messages.ToList();
//            return View(value);
//        }
//        [HttpGet]
//        public ActionResult CreateMessage()
//        {
//            return View();
//        }
//        [HttpPost]
//        public ActionResult CreateMessage(Message message)
//        {
//            context.Messages.Add(message);
//            context.SaveChanges();
//            return RedirectToAction("Index");
//        }
//        public ActionResult DeleteMessage(int id)
//        {
//            var value = context.Messages.Find(id);
//            context.Messages.Remove(value);
//            context.SaveChanges();
//            return RedirectToAction("Index");
//        }
//        public ActionResult GetMessage(int id)
//        {
//            var value = context.Messages.Find(id);
//            return View("GetMessage", value);
//        }
//        public ActionResult UpdateMessage(Message message)
//        {
//            var value = context.Messages.Find(message.MessageId);
          
//            context.SaveChanges();
//            return RedirectToAction("Index");
//        }
//    }
//}