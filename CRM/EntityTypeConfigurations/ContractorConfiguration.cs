using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using CRM.Models;

namespace CRM.EntityTypeConfigurations
{
    public class ContractorConfiguration : EntityTypeConfiguration<Contractor>
    {
        public ContractorConfiguration()
        {
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(c => c.Description)
                .HasMaxLength(500);

            Property(c => c.Email)
                .HasMaxLength(100);

            Property(c => c.Nip)
                .HasMaxLength(20);

            Property(c => c.Regon)
                .HasMaxLength(20);

            Property(c => c.ShortName)
                .HasMaxLength(100);

            Property(c => c.TelephoneNo)
                .HasMaxLength(100);
                       
            Property(c => c.Street)
                .HasMaxLength(50);

            Property(c => c.City)
                .HasMaxLength(30);

            Property(c => c.ZipCode)
                .HasMaxLength(15);

            Property(c => c.AdressDetails)
                .HasMaxLength(300);
        }
    }
}