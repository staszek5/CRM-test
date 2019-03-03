using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Models;
using CRM.ViewModels;

namespace CRM.Controllers
{
    public class ContractorEmployeeController : Controller
    {

        private ApplicationDbContext _context;

        public ContractorEmployeeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: ContractorEmployees
        public ViewResult Index(ContractorEmployee contractorEmployee)
        {
            var contractorEmployees = _context.ContractorEmployees.Where(c => c.IsActive == true)
                                              .Include(c => c.EmployeeSignificance)
                                              .Include(c => c.Contractor).ToList();

            if (contractorEmployee.Contractor != null)
            {
                if (!String.IsNullOrEmpty(contractorEmployee.Contractor.Name))
                {
                    contractorEmployees = contractorEmployees.Where(c => c.Contractor.Name == contractorEmployee.Contractor.Name).ToList();
                }
            }
            if (contractorEmployee != null)
            {
                if (!String.IsNullOrEmpty(contractorEmployee.FullName))
                {
                    contractorEmployees = contractorEmployees.Where(c => c.FullName == contractorEmployee.FullName).ToList();
                }
            }
            if (contractorEmployee.EmployeeSignificanceId != 0)
            {
                contractorEmployees = contractorEmployees.Where(c => c.EmployeeSignificanceId == contractorEmployee.EmployeeSignificanceId).ToList();
            }


            var searchContractorEmployeesViewModel = new SearchContractorEmployeesViewModel()
            {
                ContractorEmployees = contractorEmployees,
                EmployeeSignificances = _context.EmployeeSignificances.ToList(),
                Contractor = new Contractor()
            };
            
            return View(searchContractorEmployeesViewModel);
        }
        
        public ActionResult Details(int id)
        {
            //var conractor = _context.Contractors.SingleOrDefault(c => c.Id == id);
            var contractorEmployee = _context.ContractorEmployees.Include(c => c.EmployeeSignificance)
                                                                 .Include(c => c.Contractor).SingleOrDefault(c => c.Id == id);
            var employeeSignificances = _context.EmployeeSignificances.ToList();

            var viewModel = new SearchContractorEmployeesViewModel()
            {
                ContractorEmployee = contractorEmployee,
                EmployeeSignificances = employeeSignificances
            };
            //if (conractorEmployee == null)
            //{
            //    return HttpNotFound();
            //}

            return View("NewDetailsEmployee", viewModel);
        }

        public ActionResult Save(ContractorEmployee contractorEmployee)
        {

            if (contractorEmployee.Id == 0)
            {
                var newEmployee = new ContractorEmployee()
                {
                    FullName = contractorEmployee.FullName,
                    Email = contractorEmployee.Email,
                    Description = contractorEmployee.Description,
                    EmployeeSignificanceId = contractorEmployee.EmployeeSignificanceId,
                    Position = contractorEmployee.Position,
                    ContractorId = contractorEmployee.Contractor.Id,
                    TelephoneNo = contractorEmployee.TelephoneNo,
                    IsActive = true,
                    AddDate = DateTime.Now
                };
                _context.ContractorEmployees.Add(newEmployee);
            }
            else
            {
                var contractorEmployeeInDb = _context.ContractorEmployees.SingleOrDefault(c => c.Id == contractorEmployee.Id);
                contractorEmployeeInDb.FullName = contractorEmployee.FullName;
                contractorEmployeeInDb.Email = contractorEmployeeInDb.Email;
                contractorEmployeeInDb.Description = contractorEmployeeInDb.Description;
                contractorEmployeeInDb.EmployeeSignificanceId = contractorEmployee.EmployeeSignificanceId;
                contractorEmployeeInDb.Position = contractorEmployee.Position;
                contractorEmployeeInDb.ContractorId = contractorEmployee.Contractor.Id;
                contractorEmployeeInDb.TelephoneNo = contractorEmployee.TelephoneNo;
                contractorEmployeeInDb.IsActive = true;                
            }
            _context.SaveChanges();

            return RedirectToAction("Index","ContractorEmployee");
        }

        public ActionResult Delete(int id)
        {
            var contractorEmployeeInDb = _context.ContractorEmployees.SingleOrDefault(c => c.Id == id);
            contractorEmployeeInDb.IsActive = false;

            _context.SaveChanges();

            return RedirectToAction("Index", "ContractorEmployee");
        }
        public ActionResult New()
        {

            var employeeSignificances = _context.EmployeeSignificances.ToList();
            var viewModel = new SearchContractorEmployeesViewModel()
            {
                ContractorEmployee = new ContractorEmployee(),
                EmployeeSignificances = employeeSignificances
            };

            return View("NewDetailsEmployee", viewModel);
        }
        public JsonResult GetEmployees(string term = "")
        {
            var objContractorEmplooyeesList = _context.ContractorEmployees
                                        .Where(c => c.FullName.ToUpper().Contains(term.ToUpper())).Select(c => new { Name = c.FullName, ID = c.Id }).ToList();

            return Json(objContractorEmplooyeesList, JsonRequestBehavior.AllowGet);
        }
    }
}