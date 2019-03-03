using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.Models;

namespace CRM.ViewModels
{
    public class SearchTaskViewModel
    {
        public UserTask UserTask { get; set; }
        public List<UserTask> UserTasks { get; set; }
        public Contractor Contractor { get; set; }
        public ContractorEmployee ContractorEmployee { get; set; }
        public IEnumerable<UserTaskType> UserTaskType { get; set; }
    }
}