using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DiplomaCRM.Entities;

namespace DiplomaCRM.Context
{
    public partial class DiplomaCRMContext : DbContext
    {
        public DiplomaCRMContext()
        {
        }

        public DiplomaCRMContext(DbContextOptions<DiplomaCRMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<ClientType> ClientTypes { get; set; } = null!;
        public virtual DbSet<CompanyPaymentInfo> CompanyPaymentInfos { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<HelpRequest> HelpRequests { get; set; } = null!;
        public virtual DbSet<HelpStatus> HelpStatuses { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
        public virtual DbSet<OrderType> OrderTypes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseNpgsql("Server=146.185.208.133;Port=5432;Database=DiplomaCRM;Uid=DiplomaCRMAdmin;Pwd=Qos?Xko118128y1q");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("Bill");

                entity.Property(e => e.BillOrderNameGoods).HasMaxLength(150);

                entity.HasOne(d => d.BillClient)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.BillClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bill_Client");

                entity.HasOne(d => d.BillOrderType)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.BillOrderTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bill_OrderType");

                entity.HasOne(d => d.BillSenderInfo)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.BillSenderInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bill_CompanyPaymentInfo");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.ClientAddress).HasMaxLength(350);

                entity.Property(e => e.ClientEmail).HasMaxLength(256);

                entity.Property(e => e.ClientInn)
                    .HasMaxLength(12)
                    .HasColumnName("ClientINN");

                entity.Property(e => e.ClientName).HasMaxLength(100);

                entity.Property(e => e.ClientPhone).HasMaxLength(20);

                entity.HasOne(d => d.ClientEmployee)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.ClientEmployeeId)
                    .HasConstraintName("FK_Client_Employee");

                entity.HasOne(d => d.ClientTypeNavigation)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.ClientType)
                    .HasConstraintName("FK_Client_ClientType");
            });

            modelBuilder.Entity<ClientType>(entity =>
            {
                entity.ToTable("ClientType");

                entity.Property(e => e.ClientTypeValue).HasMaxLength(50);
            });

            modelBuilder.Entity<CompanyPaymentInfo>(entity =>
            {
                entity.HasKey(e => e.InfoId)
                    .HasName("CompanyPaymentInfo_pkey");

                entity.ToTable("CompanyPaymentInfo");

                entity.Property(e => e.InfoAddress).HasMaxLength(350);

                entity.Property(e => e.InfoBankCity).HasMaxLength(70);

                entity.Property(e => e.InfoBankName).HasMaxLength(200);

                entity.Property(e => e.InfoBik)
                    .HasMaxLength(9)
                    .HasColumnName("InfoBIK");

                entity.Property(e => e.InfoBookkeeper).HasMaxLength(150);

                entity.Property(e => e.InfoCorrespondentAccount).HasMaxLength(20);

                entity.Property(e => e.InfoFullName).HasMaxLength(150);

                entity.Property(e => e.InfoInn)
                    .HasMaxLength(10)
                    .HasColumnName("InfoINN");

                entity.Property(e => e.InfoPaymentAccount).HasMaxLength(20);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeFirstName).HasMaxLength(40);

                entity.Property(e => e.EmployeeLastName).HasMaxLength(40);

                entity.Property(e => e.EmployeeLogin).HasMaxLength(60);

                entity.Property(e => e.EmployeeMiddleName).HasMaxLength(40);

                entity.Property(e => e.EmployeePassword).HasMaxLength(64);

                entity.HasOne(d => d.EmployeeRoleNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeRole)
                    .HasConstraintName("FK_Employee_Role");
            });

            modelBuilder.Entity<HelpRequest>(entity =>
            {
                entity.HasKey(e => e.HelpId)
                    .HasName("HelpRequest_pkey");

                entity.ToTable("HelpRequest");

                entity.Property(e => e.HelpDescription).HasMaxLength(350);

                entity.Property(e => e.HelpSubject).HasMaxLength(50);

                entity.HasOne(d => d.HelpClient)
                    .WithMany(p => p.HelpRequests)
                    .HasForeignKey(d => d.HelpClientId)
                    .HasConstraintName("FK_HelpRequest_Client");

                entity.HasOne(d => d.HelpStatusNavigation)
                    .WithMany(p => p.HelpRequests)
                    .HasForeignKey(d => d.HelpStatus)
                    .HasConstraintName("FK_HelpRequests_HelpStatus");
            });

            modelBuilder.Entity<HelpStatus>(entity =>
            {
                entity.ToTable("HelpStatus");

                entity.Property(e => e.HelpStatusValue).HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderDescription).HasMaxLength(350);

                entity.HasOne(d => d.OrderClient)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderClientId)
                    .HasConstraintName("FK_Order_Client");

                entity.HasOne(d => d.OrderStatusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatus)
                    .HasConstraintName("FK_Order_OrderStatus");

                entity.HasOne(d => d.OrderTypeNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderType)
                    .HasConstraintName("FK_Order_OrderType");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("OrderStatus");

                entity.Property(e => e.OrderStatusValue).HasMaxLength(50);
            });

            modelBuilder.Entity<OrderType>(entity =>
            {
                entity.ToTable("OrderType");

                entity.Property(e => e.OrderTypeValue).HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleValue).HasMaxLength(40);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
