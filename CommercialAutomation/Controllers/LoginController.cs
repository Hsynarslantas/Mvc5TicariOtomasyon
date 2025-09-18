using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CommercialAutomation.Models.Classes;

namespace CommercialAutomation.Controllers
{
    public class LoginController : Controller
    {
        Context context=new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Current current)
        {
            context.Currents.Add(current);
            context.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CurrentLogin()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult CurrentLogin(Current current)
        {
           var values=context.Currents.FirstOrDefault(x=>x.CurrentMail==current.CurrentMail&&x.CurrentPassword==current.CurrentPassword);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.CurrentMail,false);
                Session["CurrentMail"] = values.CurrentMail.ToString();
                return RedirectToAction("Index", "CurrentPanel");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
          
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var result = context.Admins.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(result.Username, false);
                Session["Username"]=result.Username.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
            
        }
    }
}