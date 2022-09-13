using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DataModel.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<ActivitiesAssigned> ActivitiesAssigned { get; set; }
        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<ActivityType> ActivityType { get; set; }
        public virtual DbSet<AuditTrail> AuditTrail { get; set; }
        public virtual DbSet<AuditTrailType> AuditTrailType { get; set; }
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Bank> Bank { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Designation> Designation { get; set; }
        public virtual DbSet<DocumentUpload> DocumentUpload { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeContact> EmployeeContact { get; set; }
        public virtual DbSet<LoginActivity> LoginActivity { get; set; }
        public virtual DbSet<Publisher> Publisher { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
        public virtual DbSet<PurchaseReceiptRegister> PurchaseReceiptRegister { get; set; }
        public virtual DbSet<PurchaseReceiptRegisterDetail> PurchaseReceiptRegisterDetail { get; set; }
        public virtual DbSet<PurchaseReturn> PurchaseReturn { get; set; }
        public virtual DbSet<PurchaseReturnDetail> PurchaseReturnDetail { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<SaleInvoice> SaleInvoice { get; set; }
        public virtual DbSet<SaleInvoiceDetail> SaleInvoiceDetail { get; set; }
        public virtual DbSet<SaleIssueRegister> SaleIssueRegister { get; set; }
        public virtual DbSet<SaleReturn> SaleReturn { get; set; }
        public virtual DbSet<SaleReturnDetail> SaleReturnDetail { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<SupplyStatus> SupplyStatus { get; set; }
        public virtual DbSet<Tax> Tax { get; set; }
        public virtual DbSet<Tenant> Tenant { get; set; }
        public virtual DbSet<Token> Token { get; set; }
        public virtual DbSet<Title> Title { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PurchaseOrderDetail>()
                .Property(e => e.CostPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseReceiptRegisterDetail>()
                .Property(e => e.PurchaseRate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseReceiptRegisterDetail>()
                .Property(e => e.SaleRate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseReturnDetail>()
                .Property(e => e.BasicRate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseReturnDetail>()
                .Property(e => e.PurchaseRate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseReturnDetail>()
                .Property(e => e.SaleRate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseReturnDetail>()
                .Property(e => e.MRP)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SaleInvoiceDetail>()
                .Property(e => e.BasicRate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SaleInvoiceDetail>()
                .Property(e => e.PurchaseRate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SaleInvoiceDetail>()
                .Property(e => e.SaleRate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SaleInvoiceDetail>()
                .Property(e => e.MRP)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SaleReturnDetail>()
                .Property(e => e.BasicRate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SaleReturnDetail>()
                .Property(e => e.SaleRate)
                .HasPrecision(19, 4);
        }
    }
}
