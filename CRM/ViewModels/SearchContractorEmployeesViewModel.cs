using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.Models;

namespace CRM.ViewModels
{
    public class SearchContractorEmployeesViewModel
    {
        public List<ContractorEmployee> ContractorEmployees { get; set; }
        public ContractorEmployee ContractorEmployee { get; set; }
        public IEnumerable<EmployeeSignificance> EmployeeSignificances { get; set; }
        public Contractor Contractor { get; set; }
    }
}