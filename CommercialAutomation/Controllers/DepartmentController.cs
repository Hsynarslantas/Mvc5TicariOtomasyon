using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommercialAutomation.Models.Classes;

namespace CommercialAutomation.Controllers
{
    public class DepartmentController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            var value = context.Departments.Where(x=>x.Status==true).ToList();
            return View(value);
        }
        [Authorize(Roles ="A")]
        [HttpGet]
        public ActionResult CreateDepartmant()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDepartmant(Department department)
        {
            department.Status = true;
            context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteDepartmant(int id)
        {
            var value = context.Departments.Find(id);
            context.Departments.Remove(value);
            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetDepartmant(int id)
        {
            var value = context.Departments.Find(id);
            return View("GetDepartmant", value);
        }
        public ActionResult UpdateDepartmant(Department department)
        {
            var value = context.Departments.Find(department.DepartmentId);
            value.DepartmentName = department.DepartmentName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentDetail(int id)
        {
            var value=context.Employees.Where(x=>x.EmployeeId == id).ToList();
            var department=context.Departments.Where(x=>x.DepartmentId == id).Select(y=>y.DepartmentName).FirstOrDefault();
            ViewBag.d= department;
            return View(value);
        }
        public ActionResult DepartmentPersonelSatıs(int id)
        {
            var value=context.SalesTransactions.Where(x=>x.EmployeeId==id).ToList();
            var per=context.Employees.Where(x=>x.EmployeeId==id).Select(y=> y.EmployeeName+" "+ y.EmployeeSurname).FirstOrDefault();
            ViewBag.dp= per;
            return View(value);
        }
    }
}