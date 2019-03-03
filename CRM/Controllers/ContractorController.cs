using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using CRM.Models;
using CRM.ViewModels;
using AutoMapper;


namespace CRM.Controllers
{
    public class ContractorController : Controller
    {
        private ApplicationDbContext _context;
        public ContractorController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {

            //  var contractor = _context.Contractors.Include(c => c.CooperationType)
            //                                     .Include(c => c.ContractorBranch)
            //                                     .Include(c => c.Province).SingleOrDefault(c => c.Id == id);

            //var cooperationTypes = _context.CooperationTypes.ToList();
            //var contractorBranches = _context.ContractorBranches.ToList();
            //var provinces = _context.Provinces.ToList();
            //var contractorEmployees = _context.ContractorEmployees.Include(e => e.EmployeeSignificance).Where(c => c.ContractorId == id).ToList();

            //var viewModel = new NewContractorViewModel
            //{
            //    Contractor = contractor,
            //    CooperationTypes = cooperationTypes,
            //    ContractorBranches = contractorBranches,
            //    Provinces = provinces,
            //    ContractorEmployees = contractorEmployees
            //};

            var provinces = _context.Provinces.ToList();
            var contractorBranches = _context.ContractorBranches.ToList();
            var cooperationTypes = _context.CooperationTypes.ToList();
            var viewModel = new NewContractorViewModel
            {
                ContractorBranches = contractorBranches,
                Provinces = provinces,
                CooperationTypes = cooperationTypes,
                Contractor = new Contractor()
                
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Contractor contractor)
        {
            _context.Contractors.Add(contractor);
            _context.SaveChanges();
            return RedirectToAction("Index", "Contractor");
        }

        [HttpPost]
        public ActionResult Save(Contractor contractor)
        {
            if(contractor.Id == 0)
            {
                _context.Contractors.Add(contractor);
            }
            else
            {
                var contractorInDb = _context.Contractors.Include(c => c.CooperationType).SingleOrDefault(c => c.Id == contractor.Id);
                //use AutoMapper
                contractorInDb.AdressDetails = contractor.AdressDetails;
                contractorInDb.City = contractor.City;
                contractorInDb.ContractorBranchId = contractor.ContractorBranchId;
                contractorInDb.CooperationTypeId = contractor.CooperationTypeId;
                contractorInDb.Description = contractor.Description;
                contractorInDb.Email = contractor.Email;
                contractorInDb.IsActive = contractor.IsActive;
                contractorInDb.Name = contractor.Name;
                contractorInDb.Nip = contractor.Nip;
                contractorInDb.ProvinceId = contractor.ProvinceId;
                contractorInDb.Regon = contractor.Regon;
                contractorInDb.ShortName = contractor.ShortName;
                contractorInDb.Street = contractor.Street;
                contractorInDb.TelephoneNo = contractor.TelephoneNo;
                contractorInDb.ZipCode = contractor.ZipCode;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Contractor");
        }
        // GET: Contractor
        public ViewResult Index2()
        {
            var contractors = _context.Contractors.Include(c => c.CooperationType).ToList();            
            return View(contractors);
        }

        public ViewResult Index(string sortOrder, Contractor contractor)
        {
            
            var contractors = _context.Contractors.Where(c => c.IsActive == true)
                                                  .Include(c => c.CooperationType)
                                                  .Include(c => c.ContractorBranch).ToList();
            if (contractor != null) {
                if (!String.IsNullOrEmpty(contractor.Name))
                {
                    contractors = contractors.Where(c => c.Name == contractor.Name).ToList();
                }
                if (contractor.ContractorBranchId.HasValue)
                {
                    contractors = contractors.Where(c => c.ContractorBranchId == contractor.ContractorBranchId).ToList();
                }
                if (contractor.CooperationTypeId.HasValue)
                {
                    contractors = contractors.Where(c => c.CooperationTypeId == contractor.CooperationTypeId).ToList();
                }
                if (!String.IsNullOrEmpty(contractor.Email))
                {
                    contractors = contractors.Where(c => c.Email == contractor.Email).ToList();
                }
                if (!String.IsNullOrEmpty(contractor.TelephoneNo))
                {
                    contractors = contractors.Where(c => c.TelephoneNo == contractor.TelephoneNo).ToList();
                }
                if (!String.IsNullOrEmpty(contractor.City))
                {
                    contractors = contractors.Where(c => c.City == contractor.City).ToList();
                }
                if (contractor.ProvinceId.HasValue)
                {
                    contractors = contractors.Where(c => c.ProvinceId == contractor.ProvinceId).ToList();
                }
            }

            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "contractor_name_desc" : "";
            ViewBag.CooperationTypeSortParam = sortOrder == "CooperationType" ? "cooperationType_desc" : "CooperationType";
            ViewBag.BranchSortParam = sortOrder == "contractorBranch" ? "contractorBranch_desc" : "contractorBranch";


            switch (sortOrder)
            {
                case "contractor_name_desc":
                    contractors = contractors.OrderByDescending(c => c.Name).ToList();
                    break;
                case "cooperationType_desc":
                    contractors = contractors.OrderByDescending(c => c.CooperationType.CooperationTypeName).ToList();
                    break;
                case "CooperationType":
                    contractors = contractors.OrderBy(c => c.CooperationType.CooperationTypeName).ToList();
                    break;
                case "contractorBranch":
                    contractors = contractors.OrderBy(c => c.ContractorBranch.ContractorBranchName).ToList();
                    break;
                case "contractorBranch_desc":
                    contractors = contractors.OrderByDescending(c => c.ContractorBranch.ContractorBranchName).ToList();
                    break;
                default:
                    contractors = contractors.OrderBy(c => c.Name).ToList();
                    break;
            }

            var searchContractorsViewModel = new SearchContractorsViewModel()
            {                
                ContractorBranches = _context.ContractorBranches.ToList(),
                Contractors = contractors,
                CooperationTypes = _context.CooperationTypes.ToList(),
                Provinces = _context.Provinces.ToList()
        };

         
            return View("Index", searchContractorsViewModel);
        }

        public ActionResult Details1(int? id)
        {
            id = (id == null) ? id = 1 : id = id;
            //var conractor = _context.Contractors.SingleOrDefault(c => c.Id == id);
            var conractor = _context.Contractors.Include(c => c.CooperationType).SingleOrDefault(c =>c.Id == id);

            if (conractor == null) {
            return HttpNotFound();
            }

            return View(conractor);
        }

        public ActionResult Details(int? id)
        {
            
            //id = (id == null) ? id = 1 : id = id;

            var contractor = _context.Contractors.Include(c => c.CooperationType)
                                                 .Include(c => c.ContractorBranch)
                                                 .Include(c => c.Province).SingleOrDefault(c => c.Id == id);

            var cooperationTypes = _context.CooperationTypes.ToList();

            var contractorBranches = _context.ContractorBranches.ToList();

            var provinces = _context.Provinces.ToList();

            var contractorEmployees = _context.ContractorEmployees.Include(e => e.EmployeeSignificance).Where(c => c.ContractorId == id).ToList();

            var notes = _context.Notes.Include(n => n.ContractorEmployee).Where(n => n.ContractorId == id).ToList();

            var tasks = _context.UserTasks.Include(t => t.ContractorEmployee)
                                          .Include(t => t.UserTaskType).Where(t => t.ContractorId == id).ToList();

            var offers = _context.ContractorOffer.Include(o => o.ContractorOfferType)
                                                 .Include(o => o.ContractorEmployee).Where(o => o.ContractorId == id).ToList();

            var viewModel = new NewContractorViewModel
            {
                Contractor = contractor,
                CooperationTypes = cooperationTypes,
                ContractorBranches = contractorBranches,
                Provinces = provinces,
                ContractorEmployees = contractorEmployees,
                Notes = notes,
                Tasks = tasks,
                Offers = offers
                
            };
            return View("Details", viewModel);
        }


        public ActionResult Edit(int id)
        {
            ////
            id = 1;
            ////
            var contractor = _context.Contractors.SingleOrDefault(c => c.Id == id);

            if (contractor == null)
                return HttpNotFound();

            var viewModel = new NewContractorViewModel
            {
                Contractor = contractor,
                CooperationTypes = _context.CooperationTypes.ToList()
        };

            return View("New", viewModel);
        }

        public JsonResult GetContractor(string term = "") {

            var objContractorList = _context.Contractors
                                        .Where(c => c.Name.ToUpper().Contains(term.ToUpper())).Select(c => new {Name = c.Name, ID = c.Id }).ToList();

            return Json(objContractorList, JsonRequestBehavior.AllowGet);
        }

    }
}