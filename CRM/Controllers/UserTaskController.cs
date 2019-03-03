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
    public class UserTaskController : Controller
    {

        private ApplicationDbContext _context;
        public UserTaskController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: UserTask
        public ViewResult Index(UserTask userTask)
        {
            var userTasks = _context.UserTasks.Where(t => t.IsActive == true).Include(t => t.Contractor)
                                      .Include(t => t.ContractorEmployee)
                                      .Include(t => t.UserTaskType).ToList();
            if (userTask.Contractor != null)
            {
                if (!String.IsNullOrEmpty(userTask.Contractor.Name))
                {
                    userTasks = userTasks.Where(t => t.Contractor.Name == userTask.Contractor.Name).ToList();
                }
            }
            if(userTask.ContractorEmployee != null)
            {
                if (!String.IsNullOrEmpty(userTask.ContractorEmployee.FullName))
                {
                    userTasks = userTasks.Where(t => t.ContractorEmployee.FullName == userTask.ContractorEmployee.FullName).ToList();
                }
            }
           
            if (userTask.UserTaskTypeId != 0)
            {
                userTasks = userTasks.Where(t => t.UserTaskTypeId == userTask.UserTaskTypeId).ToList();
            }

            var userTaskTypes = _context.UserTaskTypes.ToList();

            var searchTaskViewModel = new SearchTaskViewModel()
            {
                UserTasks = userTasks,
                Contractor = new Contractor(),
                ContractorEmployee = new ContractorEmployee(),
                UserTaskType = userTaskTypes                    
            };
            return View(searchTaskViewModel);
        }
        public ActionResult New()
        {
            var userTaskType = _context.UserTaskTypes.ToList();
            var viewModel = new SearchTaskViewModel()
            {
                UserTask = new UserTask(),
                UserTaskType = userTaskType
            };
            return View("NewDetailsUserTask",viewModel);
        }
        public ActionResult Details(int id)
        {
            var userTask = _context.UserTasks.Include(n => n.Contractor)                                     
                                         .Include(n => n.UserTaskType)
                                         .Include(n => n.ContractorEmployee).SingleOrDefault(n => n.Id == id);

            var userTaskTypes = _context.UserTaskTypes.ToList();

            var searchTaskViewModel = new SearchTaskViewModel()
            {
                UserTask = userTask,                
                UserTaskType = userTaskTypes
            };
            return View("NewDetailsUserTask", searchTaskViewModel);
        }
        public ActionResult Save(UserTask userTask)
        {            
            if (userTask.Id == 0)
            {
                var newTask = new UserTask()
                {
                    TaskName = userTask.TaskName,
                    TaskDescription = userTask.TaskDescription,
                    ContractorEmployeeId = userTask.ContractorEmployee.Id,
                    ContractorId = userTask.Contractor.Id,
                    UserTaskTypeId = userTask.UserTaskTypeId,
                    AddDate = DateTime.Now,
                    DueDate = userTask.DueDate,
                    IsActive = true
                };

                _context.UserTasks.Add(newTask);
            }
            else
            {
                var userTaskInDb = _context.UserTasks.SingleOrDefault(t => t.Id == userTask.Id);
                userTaskInDb.TaskName = userTask.TaskName;
                userTaskInDb.TaskDescription = userTask.TaskDescription;
                userTaskInDb.ContractorEmployeeId = userTask.ContractorEmployee.Id;
                userTaskInDb.ContractorId = userTask.Contractor.Id;
                userTaskInDb.UserTaskTypeId = userTask.UserTaskTypeId;
                userTaskInDb.AddDate = DateTime.Now;
                userTaskInDb.DueDate = userTask.DueDate;
                userTaskInDb.IsActive = true;
            }

            _context.SaveChanges();


            return RedirectToAction("Index", "UserTask");
        }
        public ActionResult Delete(int id)
        {
            var userTaskInDb =_context.UserTasks.SingleOrDefault(t => t.Id == id);
            userTaskInDb.IsActive = false;

            _context.SaveChanges();
            return RedirectToAction("Index", "UserTask");
        }

    }
}