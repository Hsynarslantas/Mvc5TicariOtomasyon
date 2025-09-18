using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommercialAutomation.Models.Classes;

namespace CommercialAutomation.Controllers
{
    public class ToDoController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var values = context.Currents.Count().ToString();
            ViewBag.v1=values;
            var values2 = context.Products.Count().ToString();
            ViewBag.v2=values2;
            var values3=context.Categories.Count().ToString();
            ViewBag.v3=values3;
            var values4=(from x in context.Currents select x.CurrentCity).Distinct().Count().ToString();
            ViewBag.v4=values4;

            var todo = context.ToDoLists.ToList();
            return View(todo);
        }
    }
}