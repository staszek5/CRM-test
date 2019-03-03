using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Models
{
    public class EmployeeSignificance
    {
        public int Id { get; set; }
        public String EmployeeSignificanceName { get; set; }

        public bool IsActive { get; set; }
    }
}