using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using CRM.EntityTypeConfigurations;

namespace CRM.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<CooperationType> CooperationTypes { get; set; }
        public DbSet<ContractorEmployee> ContractorEmployees{ get; set; }
        public DbSet<EmployeeSignificance> EmployeeSignificances { get; set; }
        public DbSet<ContractorDependencyRelationshipType> ContractorDependencyRelationshipTypes { get; set; }
        public DbSet<ContractorDependencyRelationships> ContractorDependencyRelationships { get; set; }
        public DbSet<ContractorDependencyRelatedCompany> ContractorDependencyRelatedCompanies { get; set; }
        public DbSet<ContractorBranch> ContractorBranches { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<UserTaskType> UserTaskTypes { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<ContractorOfferType> ContractorOfferTypes { get; set; }
        public DbSet<ContractorOffer> ContractorOffer { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ContractorOfferType>()
            //    .HasMany(o => o.ContractorOffer)
            //    .WithRequired


            modelBuilder.Entity<ContractorOffer>()
                .HasRequired(n => n.Contractor)
                .WithMany(c => c.ContractorOffer)
                .WillCascadeOnDelete(false);
            
            modelBuilder.Entity<UserTask>()
                .HasRequired(n => n.Contractor)
                .WithMany(c => c.UserTasks)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Note>()
                .HasRequired(n => n.Contractor)
                .WithMany(c => c.Notes)
                .WillCascadeOnDelete(false);
                
            modelBuilder.Entity<Province>()
                .Property(p => p.ProvinceName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<ContractorBranch>()
                .Property(b => b.ContractorBranchName)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Configurations.Add(new ContractorConfiguration());
                   
            modelBuilder.Entity<ContractorEmployee>()
                .HasRequired(ce => ce.Contractor)
                .WithMany(c => c.ContractorEmployees)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContractorEmployee>()
                .Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(255);
            /*
            modelBuilder.Entity<ContractorsRelation>()
                .HasKey(c => c.IdContractorRelation)
                .ToTable("tContractorsRelations");
*/
            modelBuilder.Entity<ContractorDependencyRelationships>()
                .HasRequired(c => c.Contractor)
                .WithMany(r => r.ContractorDependencyRelationships)
                .WillCascadeOnDelete(false);
         //08.04   
            modelBuilder.Entity<ContractorDependencyRelationships>()
                .HasRequired(c => c.ContractorDependencyRelationshipType)
                .WithMany(r => r.ContractorDependencyRelationships)
                .WillCascadeOnDelete(false);
            

            /*
            modelBuilder.Entity<ContractorDependencyRelationshipType>()
                .HasMany(t => t.ContractorDependencyRelationships)
                .WithRequired(r => r.ContractorDependencyRelationshipType)
                .WillCascadeOnDelete(false);
*/
            /* modelBuilder.Entity<ContractorDependencyRelationshipType>()
                 .HasKey(t => t.IdContractorsRelationType)
                 .ToTable("tContractorsRelationTypes");
                 */

            modelBuilder.Entity<ContractorDependencyRelatedCompany>()
               .HasKey(r => r.ContractorDependencyRelationshipsId);

            modelBuilder.Entity<ContractorDependencyRelationships>()
                .HasRequired(cr => cr.ContractorDependencyRelatedCompany)
                .WithRequiredPrincipal(rc => rc.ContractorDependencyRelationships);
                

            //modelBuilder.Entity<ContractorDependencyRelatedCompanies>()
            //    .HasKey(r => r.IdContractorsRelatedCompany);

            /*
            modelBuilder.Entity<ContractorDependencyRelatedCompanies>()
                .HasRequired<Contractor>(c => c.Contractor)
                .WithMany(c => c.ContractorDependencyRelatedCompanies)
                .HasForeignKey(c => c.IdContractor)
                .WillCascadeOnDelete(false);
           */



            /*
            modelBuilder.Entity<ContractorsRelation>()
                .HasRequired(c => c.Contractor1)
                .WithMany(cr => cr.ContractorDependencyRelationships);
                */
            // modelBuilder.Entity<ContractorsRelation>()
            //     .HasRequired(c => c.Contractor2)
            //     .WithMany(cr => cr.ContractorDependencyRelationships);

            /* modelBuilder.Entity<Contractor>()
                 .HasMany(r => r.CooperationTypeId);
        */
        
            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext()
            : base("name=DefaultConnection", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}