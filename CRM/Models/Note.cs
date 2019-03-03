using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace CRM.Models
{
    public class Note
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name ="Temat Notatki")]
        public String NoteName { get; set; }

        [StringLength(500)]
        [Display(Name = "Treść Notatki")]
        public string NoteDescription { get; set; }

        public int ContractorId { get; set; }
        public Contractor Contractor { get; set; }

        public int? ContractorEmployeeId { get; set; }
        public ContractorEmployee ContractorEmployee { get; set; }

        [Display(Name = "Data dodania")]
        public DateTime? AddDate { get; set; }

        public bool IsActive { get; set; }
    }
}