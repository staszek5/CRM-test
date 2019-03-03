using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Models
{
    public class UserTaskType
    {
        public int Id { get; set; }
        public String TaskTypeName { get; set; }

        public bool IsActive { get; set; }
    }
}