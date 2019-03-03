using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Data.Entity;
using CRM.Models;
using CRM.ViewModels;


namespace CRM.Controllers
{
    public class NoteController : Controller
    {

        private ApplicationDbContext _context;
        public NoteController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index(Note note)
        {
            var notes = _context.Notes.Where(n => n.IsActive == true).Include(n => n.Contractor)
                                      .Include(n => n.ContractorEmployee).ToList();
               
            if(note.NoteName != null)
            {
                if (!String.IsNullOrEmpty(note.NoteName)){
                    notes = notes.Where(n => n.NoteName.ToLower().StartsWith(note.NoteName.ToLower())).ToList();
                }                
            }
            if(note.Contractor != null)
            {
                if (!String.IsNullOrEmpty(note.Contractor.Name)){
                    notes = notes.Where(n => n.Contractor.Name == note.Contractor.Name).ToList();
                }                
            }
            if(note.ContractorEmployee != null)
            {
                if (!String.IsNullOrEmpty(note.ContractorEmployee.FullName)) {
                    notes = notes.Where(n => n.ContractorEmployee.FullName == note.ContractorEmployee.FullName).ToList();
                }                
            }


            var searchNoteViewModel = new SearchNoteViewModel()
            {
                Notes = notes,
                Contractors = new List<Contractor>(),
                Contractor = new Contractor(),
                ContractorEmployee = new ContractorEmployee()
                
            };

            return View(searchNoteViewModel);            
        }

        public ActionResult New() {

            var note = new Note();
            var viewModel = new SearchNoteViewModel()
            {

            };

            return View("NewDetailsNote", note );
        }
        
        public ActionResult Details(int id)
        {
            var note = _context.Notes.Include(n => n.Contractor)
                                     .Include(n => n.ContractorEmployee).SingleOrDefault(n => n.Id == id);

            return View("NewDetailsNote", note);
        }

        public ActionResult Save(Note note)
        {
            if (!ModelState.IsValid)
            {
                //var viewModel = new SearchNoteViewModel()
                //{
                //    Note = note
                //};


                return View("NewDetailsNote", note);
            }

            if(note.Id == 0)
            {
                var newNote = new Note()
                {
                    NoteName = note.NoteName,
                    NoteDescription = note.NoteDescription,
                    ContractorId = note.Contractor.Id,
                    ContractorEmployeeId = note.ContractorEmployee.Id,
                    IsActive = true,
                    AddDate = DateTime.Now
                };

                _context.Notes.Add(newNote);
            }
            else
            {
                var noteInDb = _context.Notes.SingleOrDefault(n => n.Id == note.Id);
                noteInDb.NoteName = note.NoteName;
                noteInDb.NoteDescription = note.NoteDescription;
                noteInDb.ContractorId = note.Contractor.Id;
                noteInDb.ContractorEmployeeId = note.ContractorEmployee.Id;
                noteInDb.AddDate = DateTime.Now;
                
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Note");
        }

        public ActionResult Delete(int id)
        {
            var noteInDb = _context.Notes.SingleOrDefault(n => n.Id == id);
            noteInDb.IsActive = false;

            _context.SaveChanges();

            return RedirectToAction("Index", "Note");
        }

        // GET: Note
        //public ActionResult Index()
        //{
        //    return View();
        //}

    }
}