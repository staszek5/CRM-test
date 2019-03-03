using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CRM.Models
{
    public class Contractor
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa Kontrahenta")]
        public string Name { get; set; }

        [Display(Name = "Skrócona Nazwa Kontrahenta")]
        public string ShortName { get; set; }

        [Display(Name = "Opis Kontrahenta")]
        public string Description { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Numer Telefonu")]
        public string TelephoneNo { get; set; }

        [Display(Name = "NIP")]
        public string Nip { get; set; }

        [Display(Name = "REGON")]
        public string Regon { get; set; }

        //adress

        [Display(Name = "Ulica")]
        public string Street { get; set; }

        [Display(Name = "Miasto")]
        public string City { get; set; }

        [Display(Name = "Kod Pocztowy")]
        public string  ZipCode { get; set; }


        [Display(Name = "Informacje Szczegółowe")]
        public string AdressDetails { get; set; }
        //group
        //add_user_id

        public bool IsActive { get; set; }

        [Display(Name = "Grupa/Typ Współpracy")]
        public int? CooperationTypeId { get; set; }
        public CooperationType CooperationType { get; set; }

        [Display(Name = "Województwo")]
        public int? ProvinceId { get; set; }
        public Province Province { get; set; }

        [Display(Name = "Obszar Działania/Branża")]
        public int? ContractorBranchId { get; set; }
        public ContractorBranch ContractorBranch { get; set; }

        public List<ContractorEmployee> ContractorEmployees { get; set; }

        public List<Note> Notes { get; set; }

        public List<UserTask> UserTasks { get; set; }

        public List<ContractorOffer> ContractorOffer { get; set; }

        [Display(Name = "Data dodania")]
        public DateTime? AddDate { get; set; }

        public List<ContractorDependencyRelationships> ContractorDependencyRelationships { get; set; }

        public List<ContractorDependencyRelatedCompany> ContractorsRelatedCompany { get; set; }
       
    }
}