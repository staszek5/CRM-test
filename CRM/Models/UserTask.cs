using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    public class UserTask
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Temat Zadania")]
        public String TaskName { get; set; }

        [StringLength(500)]
        [Display(Name = "Opis Zadania")]
        public string TaskDescription { get; set; }

        public int ContractorId { get; set; }
        public Contractor Contractor { get; set; }

        public int? ContractorEmployeeId { get; set; }
        public ContractorEmployee ContractorEmployee { get; set; }

        [Display(Name = "Typ Zadania")]
        public int UserTaskTypeId { get; set; }
        public UserTaskType UserTaskType { get; set; }

        [Display(Name = "Data dodania")]
        public DateTime? AddDate { get; set; }

        [Display(Name = "Data Wykonania")]
        public DateTime? DueDate { get; set; }

        public bool IsActive { get; set; }
    }
}