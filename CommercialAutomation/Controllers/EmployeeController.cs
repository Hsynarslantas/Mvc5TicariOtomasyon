using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommercialAutomation.Models.Classes;

namespace CommercialAutomation.Controllers
{
    public class EmployeeController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            var value = context.Employees.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CreateEmployee()
        {
            List<SelectListItem> deger1 = (from x in context.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.dp = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            if(Request.Files.Count > 0)
            {
                string filenames=Path.GetFileName(Request.Files[0].FileName);
                string cookies=Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + filenames + cookies;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                employee.EmployeeImageUrl ="/Image/" +filenames + cookies;
            }
            context.Employees.Add(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEmployee(int id)
        {
            var value = context.Employees.Find(id);
            context.Employees.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetEmployee(int id)
        {
            List<SelectListItem> deger1 = (from x in context.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.dp = deger1;
            var value = context.Employees.Find(id);
            return View("GetEmployee", value);
        }
        public ActionResult UpdateEmployee(Employee employee)
        {
            var value = context.Employees.Find(employee.EmployeeId);
            value.EmployeeName = employee.EmployeeName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EmployeeList()
        {
            var values=context.Employees.ToList();
            return View(values);
        }
    }
}