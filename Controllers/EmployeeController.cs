using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CRUDOperations.Models;

namespace MVC_CRUDOperations.Controllers
{
    public class EmployeeController : Controller
    {
        private MVC_CRUD_dbc dbc;
        public EmployeeController()
        {
            dbc=new MVC_CRUD_dbc();
        }
        public IActionResult Index()
        {
            List<Employee> employees=dbc.employees.ToList();
            return View(employees);
        }
        [HttpGet]
        [Route("Employee/GetById/{Ssn:int}")]
        public IActionResult GetById(int Ssn)
        {
            Employee? emp = dbc.employees.SingleOrDefault(emp => emp.Ssn == Ssn);
            return emp == null? View("Error"): View(emp); 
        }
        public IActionResult Add()
        {
            List<Employee> employees = dbc.employees.ToList();
            return View(employees);
        }
        public IActionResult AddEmpDb(Employee emp)
        {
            dbc.employees.Add(emp);
            dbc.SaveChanges();

            List<Employee> employees = dbc.employees.ToList();
            return RedirectToAction("Index",employees);
        }
        public IActionResult Edit(int id)
        {
            Employee emp = dbc.employees.SingleOrDefault(emp => emp.Ssn == id);
            List<Employee> employees = dbc.employees.ToList();
            ViewBag.ins = employees;
            return View(emp);
        }
        public IActionResult EditEmpDb(Employee emp)
        {
            Employee oldEmp = dbc.employees.SingleOrDefault(e => e.Ssn == emp.Ssn);
            oldEmp.Fname = emp.Fname;
            oldEmp.Mname = emp.Mname;
            oldEmp.Lname = emp.Lname;
            oldEmp.Bdate = emp.Bdate;
            oldEmp.Address= emp.Address;
            oldEmp.Sex= emp.Sex;
            oldEmp.Salary= emp.Salary;
            oldEmp.SuperID = emp.SuperID;
            dbc.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Employee emp = dbc.employees.SingleOrDefault(emp => emp.Ssn == id);
            dbc.employees.Remove(emp);
            dbc.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
