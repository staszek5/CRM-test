using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    public class ContractorEmployee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Pracownik Kontrahenta")]
        public String FullName { get; set; }

        public int ContractorId { get; set; }
        public Contractor Contractor { get; set; }

        [Display(Name = "Informacje o pracowniku")]
        [StringLength(500)]
        public string Description { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Numer Telefonu")]
        public string TelephoneNo { get; set; }

        [Display(Name = "Stanowisko")]
        public string Position { get; set; }

        public List<Note> Notes { get; set; }

        public List<UserTask> UserTasks { get; set; }

        public List<ContractorOffer> ContractorOffer { get; set; }

        
        public EmployeeSignificance EmployeeSignificance { get; set; }
        [Display(Name = "Ranga Pracownika")]
        public int EmployeeSignificanceId { get; set; }

        public DateTime? AddDate { get; set; }

        public bool IsActive { get; set; }
    }
}