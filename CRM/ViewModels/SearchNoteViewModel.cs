using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.Models;

namespace CRM.ViewModels
{
    public class SearchNoteViewModel
    {
        public List<Note> Notes { get; set; }
        public Note Note { get; set; }
        public List<Contractor> Contractors { get; set; }
        public Contractor Contractor { get; set; }
        public ContractorEmployee ContractorEmployee { get; set; }
    }
}