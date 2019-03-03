using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Models
{
    public class Province
    {
        public int Id { get; set; }
        public String ProvinceName { get; set; }

        public bool IsActive { get; set; }
    }
}