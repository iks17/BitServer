using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BitServerBL.Models
{
    public partial class BitDBContext : DbContext
    {
        public BitDBContext()
        {
        }

        public BitDBContext(DbContextOptions<BitDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<BusinessAccount> BusinessAccounts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<PrivateAccount> PrivateAccounts { get; set; }
        public virtual DbSet<TransactionLog> TransactionLogs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=BitDB;Trusted_Connection=True;");
            }
        }

        public string Test()
        {


            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.AdminId)
                    .ValueGeneratedNever()
                    .HasColumnName("AdminID");

                entity.Property(e => e.LastOnline).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("admins_userid_foreign");
            });

            modelBuilder.Entity<BusinessAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("businessaccounts_accountid_primary");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(255)
                    .HasColumnName("AccountID");

                entity.Property(e => e.AnualIncome).HasColumnName("Anual Income");

                entity.Property(e => e.BusibessAdress)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.BusinessEmail)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.BusinessName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.BusinessOpenDate).HasColumnType("date");

                entity.Property(e => e.BusinessPassword)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.MainCurrency)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.BusinessAccounts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("businessaccounts_customerid_foreign");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("CustomerID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("First Name");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsFixedLength(true);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customers_userid_foreign");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.Property(e => e.LoanId)
                    .ValueGeneratedNever()
                    .HasColumnName("LoanID");

                entity.Property(e => e.BusinessId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("BusinessID");

                entity.Property(e => e.PrivateId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("PrivateID");

                entity.HasOne(d => d.ApprovedByNavigation)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.ApprovedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("loans_approvedby_foreign");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("loans_businessid_foreign");

                entity.HasOne(d => d.Private)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.PrivateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("loans_privateid_foreign");
            });

            modelBuilder.Entity<PrivateAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("privateaccounts_accountid_primary");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(255)
                    .HasColumnName("AccountID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.MainCurrency)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.PrivateAccounts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("privateaccounts_customerid_foreign");
            });

            modelBuilder.Entity<TransactionLog>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("transactionlogs_transactionid_primary");

                entity.Property(e => e.TransactionId)
                    .ValueGeneratedNever()
                    .HasColumnName("TransactionID");

                entity.Property(e => e.ReceiverAccount)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ReceiverId).HasColumnName("ReceiverID");

                entity.Property(e => e.SenderAccount)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SenderId).HasColumnName("SenderID");

                entity.Property(e => e.TransactionDate).HasColumnType("date");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.TransactionLogReceivers)
                    .HasForeignKey(d => d.ReceiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("transactionlogs_receiverid_foreign");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.TransactionLogSenders)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("transactionlogs_senderid_foreign");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasColumnName("Phone Number");

                entity.Property(e => e.RegistartionDate).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
