using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.Models;

namespace CRM.ViewModels
{
    public class SearchOfferViewModel
    {
        public ContractorOffer ContractorOffer { get; set; }
        public List<ContractorOffer> ContractorOffers { get; set; }
        public Contractor Contractor { get; set; }
        public ContractorEmployee ContractorEmployee { get; set; }
        public List<ContractorOfferType> ContractorOfferTypes { get; set; }
    }
}