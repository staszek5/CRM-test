using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Models
{
    public class ContractorDependencyRelationshipType
    {
        public int Id{ get; set; }
        public String RelationType { get; set; }

        public List<ContractorDependencyRelationships> ContractorDependencyRelationships { get; set; }


    }
}