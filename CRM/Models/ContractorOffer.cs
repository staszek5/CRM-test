using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    public class ContractorOffer
    {
        public int Id { get; set; }

        [Display(Name = "Temat Ofetry")]
        public String OfferName { get; set; }

        [Display(Name = "Opis Ofetry")]
        public String OfferDesctiption { get; set; }

        [Display(Name = "Typ Oferty")]
        public int? ContractorOfferTypeId { get; set; }
        public ContractorOfferType ContractorOfferType { get; set; }

        public int ContractorId { get; set; }
        public Contractor Contractor { get; set; }

        public int? ContractorEmployeeId { get; set; }
        public ContractorEmployee ContractorEmployee { get; set; }

        [Display(Name = "Data Dodania")]
        public DateTime? AddDate { get; set; }

        [Display(Name = "Data Ważności Oferty")]
        public DateTime? ExpirationDate { get; set; }

        [Display(Name = "Data Akceptacji Oferty")]
        public DateTime? AcceptanceDate { get; set; }

        public bool IsActive { get; set; }
    }
}