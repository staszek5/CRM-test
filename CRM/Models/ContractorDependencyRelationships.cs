using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Models
{
    public class ContractorDependencyRelationships
    {
        public int Id { get; set; }
        public Contractor Contractor { get; set; }
        public int ContractorId{ get; set; }

        public ContractorDependencyRelationshipType ContractorDependencyRelationshipType { get; set; }
        public int ContractorDependencyRelationshipTypeId { get; set; }

        public ContractorDependencyRelatedCompany ContractorDependencyRelatedCompany { get; set; }
        public int ContractorDependencyRelatedCompanyId { get; set; }
             

    }
}