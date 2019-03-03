using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.Models;

namespace CRM.ViewModels
{
    public class NewContractorViewModel
    {
        public IEnumerable<CooperationType> CooperationTypes { get; set; }
        public Contractor Contractor { get; set; }
        public IEnumerable<ContractorBranch> ContractorBranches { get; set; }
        public IEnumerable<Province> Provinces { get; set; }
        public List<ContractorEmployee> ContractorEmployees { get; set; }
        public List<Note> Notes { get; set; }
        public List<UserTask> Tasks { get; set; }
        public List<ContractorOffer> Offers { get; set; }
    }
}