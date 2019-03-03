using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.Models;

namespace CRM.ViewModels
{
    public class SearchContractorsViewModel
    {
        public List<Contractor> Contractors { get; set; }
        public IEnumerable<CooperationType> CooperationTypes { get; set; }
        public Contractor Contractor { get; set; }
        public IEnumerable<ContractorBranch> ContractorBranches { get; set; }
        public IEnumerable<Province> Provinces { get; set; }
    }
}