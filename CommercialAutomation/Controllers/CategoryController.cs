using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommercialAutomation.Models.Classes;
using PagedList;
using PagedList.Mvc;

namespace CommercialAutomation.Controllers
{
    public class CategoryController : Controller
    {
        Context context=new Context();
       
        public ActionResult Index(int page=1)
        {
            var value = context.Categories.ToList().ToPagedList(page, 10);
          return View(value);
        }
        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id)
        {
            var value=context.Categories.Find(id);
            context.Categories.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCategory(int id)
        {
            var value = context.Categories.Find(id);
            return View("GetCategory",value);
        }
        public ActionResult UpdateCategory(Category category)
        {
            var value = context.Categories.Find(category.CategoryId);
            value.CategoryName=category.CategoryName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
      
   
    }
}