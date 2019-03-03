using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    public class ContractorOfferType
    {
        
        public int Id { get; set; }
        
        public String OfferTypeName { get; set; }

        public bool IsActive { get; set; }
    }
}