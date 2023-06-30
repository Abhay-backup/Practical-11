using Practical_11_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_11_1.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Employees> EmployeesList = new List<Employees>()
        {
            new Employees() {Id=1, Name="Abhay",DOB=DateTime.Parse("06-10-2001").Date , Address="Gondal"},
            new Employees() {Id=2, Name="Jay",DOB=DateTime.Parse("21-08-2002").Date, Address="Rajkot"},
            new Employees() {Id=3, Name="Parthiv",DOB=DateTime.Parse("15-05-2001").Date, Address="Rajkot"},
            new Employees() {Id=4, Name="Stuti",DOB=DateTime.Parse("20-04-2001").Date, Address="Jamnagar"}
        };

        // GET: Employee
        public ActionResult Test1()
        {
            return View(EmployeesList);
        }



        public ActionResult Delete(int? id)
        {
            var st = EmployeesList.Find(e => e.Id == id);
            return View(st);
        }
        [HttpPost]
        public ActionResult Delete(Employees em)
        {
            var st = EmployeesList.Find(e => e.Id == em.Id);
            EmployeesList.Remove(st);
            return RedirectToAction("Test1");
        }



        public ActionResult Create()
        {
            return View(new Employees());
        }

        [HttpPost]
        public ActionResult Create(Employees model)
        {
            int id = EmployeesList.Count + 1;
            var emp = new Employees()
            {
                Id = id,
                Name = model.Name,
                DOB = model.DOB,
                Address = model.Address
            };
            EmployeesList.Add(emp);
            return RedirectToAction("Test1", emp);
        }
        public ActionResult Edit(int id)
        {
            var emp = EmployeesList.SingleOrDefault(e => e.Id == id);
            var result = new Employees()
            {
                Id = emp.Id,
                Name = emp.Name,
                DOB = emp.DOB,
                Address = emp.Address
            };
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(int id, Employees model)
        {
            var emp = EmployeesList.Find(e => e.Id == id);
            emp.Name = model.Name;
            emp.DOB = model.DOB;
            emp.Address = model.Address;


            return RedirectToAction("Test1", emp);
        }


        public ActionResult Details(int id)
        {
            var emp = EmployeesList.FirstOrDefault(e => e.Id == id);
            return View(emp);
        }
    }
}