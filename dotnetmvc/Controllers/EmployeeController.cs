using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetmvc.Models;
using Microsoft.AspNetCore.Mvc;
  
namespace dotnetmvc.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View(Repository.AllEmpoyees);
        }
  
        // HTTP GET VERSION
        public IActionResult Create()
        {
            return View();
        }
  
        // HTTP POST VERSION  
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            Repository.Create(employee);
            return View("Thanks", employee);
        }
         public IActionResult Update(string empname)
        {
            Employee employee = Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault();
            return View(employee);
        }
  
        [HttpPost]
        public IActionResult Update(Employee employee, string empname)
        {
            Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault().Age = employee.Age;
            Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault().Salary = employee.Salary;
            Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault().Department = employee.Department;
            Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault().Sex = employee.Sex;
            Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault().Name = employee.Name;
  
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(string empname)
        {
            Employee employee = Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault();
            Repository.Delete(employee);
            return RedirectToAction("Index");
        }
    }
}