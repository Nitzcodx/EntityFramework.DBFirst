using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.IO;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace EF.DBFirst.DataAccessLayer.Models
{
    public partial class InSystContext : DbContext
    {
        public InSystContext()
        {
        }

        public InSystContext(DbContextOptions<InSystContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BranchDetail> BranchDetails { get; set; }
        public virtual DbSet<ChildCareerPolicy> ChildCareerPolicies { get; set; }
        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Policy> Policies { get; set; }
        public virtual DbSet<PolicyCategory> PolicyCategories { get; set; }
        public virtual DbSet<PolicyStatus> PolicyStatuses { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<TransactionDetail> TransactionDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().
                            SetBasePath(Directory.GetCurrentDirectory()).
                            AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("InSystDBConnectionString");

            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code.
//                You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration 
//                    - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings,
//                                //see http://go.microsoft.com/fwlink/?LinkId=723263.

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BranchDetail>(entity =>
            {
                entity.HasKey(e => e.BranchId)
                    .HasName("pk_BranchId");

                entity.HasIndex(e => e.BranchName, "uk_BranchName")
                    .IsUnique();

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BranchManager)
                    .WithMany(p => p.BranchDetails)
                    .HasForeignKey(d => d.BranchManagerId)
                    .HasConstraintName("fk_BranchManagerId");
            });

            modelBuilder.Entity<ChildCareerPolicy>(entity =>
            {
                entity.HasKey(e => e.QuoteId)
                    .HasName("pk_QuoteId");

                entity.Property(e => e.BeneficiaryDob)
                    .HasColumnType("date")
                    .HasColumnName("BeneficiaryDOB");

                entity.Property(e => e.BeneficiaryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Comment)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EffectiveDate).HasColumnType("date");

                entity.Property(e => e.ExpiryDate).HasColumnType("date");

                entity.Property(e => e.NomineeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NomineeRelation)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PercentageRebate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PremiumAmount).HasColumnType("money");

                entity.Property(e => e.PremiumMode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PremiumModeBasedRebate).HasColumnType("money");

                entity.Property(e => e.RebateMode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SumAssured).HasColumnType("money");

                entity.Property(e => e.Term).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TermEndBasedRebate).HasColumnType("money");

                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.ChildCareerPolicies)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_BranchId");

                entity.HasOne(d => d.Insured)
                    .WithMany(p => p.ChildCareerPolicies)
                    .HasForeignKey(d => d.InsuredId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_InsuranceId");
            });

            modelBuilder.Entity<Credential>(entity =>
            {
                entity.HasIndex(e => new { e.UserName, e.UserPassword }, "uk_UserName_UserPassword")
                    .IsUnique();

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Credentials)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("fk_RoleID");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId)
                    .HasName("pk_CustId");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Credential)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CredentialId)
                    .HasConstraintName("fk_CredentailId");
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.HasIndex(e => e.PolicyType, "uk_PolicyType")
                    .IsUnique();

                entity.Property(e => e.PolicyType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PolicyCategory>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.PolicyCategoryId, "uk_PolicyCategoryId")
                    .IsUnique();

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PolicyCategoryId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PolicyCategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PolicyType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.PolicyTypeNavigation)
                    .WithMany()
                    .HasPrincipalKey(p => p.PolicyType)
                    .HasForeignKey(d => d.PolicyType)
                    .HasConstraintName("fk_PolicyType");
            });

            modelBuilder.Entity<PolicyStatus>(entity =>
            {
                entity.HasKey(e => e.ApprovalId)
                    .HasName("pk_ApprovalId");

                entity.ToTable("PolicyStatus");

                entity.Property(e => e.Comment)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.PolicyStatuses)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_BranchId2");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.PolicyStatuses)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CustId");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.RoleName, "uk_RoleName")
                    .IsUnique();

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TransactionDetail>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("pk_TransactionId");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TransactionTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.TransactionDetails)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CustId1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
