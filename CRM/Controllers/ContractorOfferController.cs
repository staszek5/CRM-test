using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CRM.Models;
using CRM.ViewModels;

namespace CRM.Controllers
{
    public class ContractorOfferController : Controller
    {
        

        private ApplicationDbContext _context;
        public ContractorOfferController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: ContractorOffer
        //public ViewResult Index()
        //{
        //    var contractorOffers = _context.ContractorOffer.Include(n => n.Contractor)
        //                              .Include(n => n.ContractorEmployee)
        //                              .Include(t => t.ContractorOfferType).ToList();

        //    var searchOfferViewModel = new SearchOfferViewModel()
        //    {
        //        ContractorOffers = contractorOffers,
        //        Contractor = new Contractor(),
        //        ContractorEmployee = new ContractorEmployee()

        //    };
        //    return View(searchOfferViewModel);
        //}

        public ViewResult Index( ContractorOffer contractorOffer)
        {

            var contractorOffers = _context.ContractorOffer.Where(co => co.IsActive == true).Include(co => co.Contractor)
                                      .Include(co => co.ContractorEmployee)
                                      .Include(co => co.ContractorOfferType).ToList();

            if (contractorOffer.Contractor != null)
            {
                if (!String.IsNullOrEmpty(contractorOffer.Contractor.Name))
                {
                    contractorOffers = contractorOffers.Where(co => co.Contractor.Name == contractorOffer.Contractor.Name).ToList();
                }

            }
            if (contractorOffer.ContractorEmployee != null)
            {
                if (!String.IsNullOrEmpty(contractorOffer.ContractorEmployee.FullName))
                {
                    contractorOffers = contractorOffers.Where(co => co.ContractorEmployee.FullName == contractorOffer.ContractorEmployee.FullName).ToList();
                }
            }

            if (contractorOffer.ContractorOfferTypeId.HasValue)
            {
                contractorOffers = contractorOffers.Where(co => co.ContractorOfferTypeId == contractorOffer.ContractorOfferTypeId).ToList();
            }




            var contractorOfferTypes = _context.ContractorOfferTypes.ToList();

            var searchOfferViewModel = new SearchOfferViewModel()
            {
                ContractorOffers = contractorOffers,
                Contractor = new Contractor(),
                ContractorEmployee = new ContractorEmployee(),
                ContractorOffer = new ContractorOffer(),
                ContractorOfferTypes = contractorOfferTypes

            };
            return View(searchOfferViewModel);
        }


            public ActionResult New()
        {
            var contractorOfferTypes = _context.ContractorOfferTypes.ToList();
            var viewModel = new SearchOfferViewModel()
            {
                ContractorOffer = new ContractorOffer(),
                ContractorOfferTypes = contractorOfferTypes
            };
            return View("NewDetailsOffer", viewModel);
        }
        public ActionResult Details(int id)
        {
            var contrctorOffer = _context.ContractorOffer.Include(co => co.Contractor)
                                         .Include(co => co.ContractorOfferType)
                                         .Include(co => co.ContractorEmployee).SingleOrDefault(co => co.Id == id);

            var contractorOfferTypes = _context.ContractorOfferTypes.ToList();

            var searchOfferViewModel = new SearchOfferViewModel()
            {
                ContractorOfferTypes = contractorOfferTypes,
                ContractorOffer = contrctorOffer
            };
            return View("NewDetailsOffer", searchOfferViewModel);
        }

        public ActionResult Delete(int id)
        {
            var contractorOfferInDb = _context.ContractorOffer.SingleOrDefault(co => co.Id == id);

            contractorOfferInDb.IsActive = false;

            _context.SaveChanges();
            return RedirectToAction("Index", "ContractorOffer");
        }
        
        public ActionResult Save(ContractorOffer contractorOffer)
        {
            if(contractorOffer.Id == 0)
            {
                //prepare new object
                var newOffer = new ContractorOffer()
                {
                    OfferName = contractorOffer.OfferName,
                    OfferDesctiption = contractorOffer.OfferDesctiption,
                    ContractorOfferTypeId = contractorOffer.ContractorOfferTypeId,
                    ContractorId = contractorOffer.Contractor.Id,
                    ContractorEmployeeId = contractorOffer.ContractorEmployee.Id,
                    ExpirationDate = contractorOffer.ExpirationDate,
                    AcceptanceDate = contractorOffer.AcceptanceDate,
                    AddDate = DateTime.Now,
                    IsActive = true


            };

                //Fixed dates for test!!

               // newOffer.ExpirationDate = DateTime.Now;
               // newOffer.AcceptanceDate = DateTime.Now;
               
                _context.ContractorOffer.Add(newOffer);
            }
            else
            {
                var contractorOfferInDb = _context.ContractorOffer.SingleOrDefault(co => co.Id == contractorOffer.Id);
                contractorOfferInDb.OfferName = contractorOffer.OfferName;
                contractorOfferInDb.OfferDesctiption = contractorOffer.OfferDesctiption;
                contractorOfferInDb.ContractorOfferTypeId = contractorOffer.ContractorOfferTypeId;
                contractorOfferInDb.ContractorId = contractorOffer.Contractor.Id;
                contractorOfferInDb.ContractorEmployeeId = contractorOffer.ContractorEmployee.Id;
                contractorOfferInDb.ExpirationDate = contractorOffer.ExpirationDate;
                contractorOfferInDb.AcceptanceDate = contractorOffer.AcceptanceDate;
                //contractorOfferInDb.AddDate = contractorOffer.AddDate;
                contractorOfferInDb.IsActive = true;

                
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "ContractorOffer");
        }


    }

}