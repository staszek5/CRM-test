using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    public class ContractorDependencyRelatedCompany
    {
        //[Key]
       // public int Id { get; set; }

        public ContractorDependencyRelationships ContractorDependencyRelationships{ get; set; }
        public int ContractorDependencyRelationshipsId { get; set; }
        public Contractor Contractor { get; set; }
        public int ContractorId { get; set; }

        public bool IsActive { get; set; }
    }
}