using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OFOP.Entity.Models;

namespace OFOP.Infrastructure;

public partial class OFDPContext : DbContext
{
    public OFDPContext(DbContextOptions<OFDPContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuType> MenuTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Menu>(entity =>
        {
            entity.ToTable("Menu");

            entity.Property(e => e.MenuId)
                .ValueGeneratedNever()
                .HasColumnName("Menu_ID");
            entity.Property(e => e.Ingredients).HasMaxLength(500);
            entity.Property(e => e.MenuActive).HasColumnName("Menu_Active");
            entity.Property(e => e.MenuImage)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Menu_Image");
            entity.Property(e => e.MenuName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Menu_Name");
            entity.Property(e => e.MenuTypeId).HasColumnName("Menu_Type_ID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MenuType).WithMany(p => p.Menus)
                .HasForeignKey(d => d.MenuTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Menu_Menu_Type");
        });

        modelBuilder.Entity<MenuType>(entity =>
        {
            entity.ToTable("Menu_Type");

            entity.Property(e => e.MenuTypeId)
                .ValueGeneratedNever()
                .HasColumnName("Menu_Type_ID");
            entity.Property(e => e.TypeName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Type_Name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("Order_ID");
            entity.Property(e => e.CustId).HasColumnName("Cust_ID");
            entity.Property(e => e.IsPaid).HasColumnName("Is_Paid");
            entity.Property(e => e.MenuId).HasColumnName("Menu_ID");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("Order_Date");
            entity.Property(e => e.OrderStatus).HasColumnName("Order_status");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.TotAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Tot_Amount");

            entity.HasOne(d => d.Cust).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Customer");

            entity.HasOne(d => d.Menu).WithMany(p => p.Orders)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Menu");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Order_Status");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId);

            entity.ToTable("Order_Status");

            entity.Property(e => e.StatusId)
                .ValueGeneratedNever()
                .HasColumnName("StatusID");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(20);
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.ToTable("Rating");

            entity.Property(e => e.RatingId)
                .ValueGeneratedNever()
                .HasColumnName("Rating_ID");
            entity.Property(e => e.CustId).HasColumnName("Cust_ID");
            entity.Property(e => e.DateRecorded)
                .HasColumnType("datetime")
                .HasColumnName("Date_recorded");
            entity.Property(e => e.MenuId).HasColumnName("Menu_ID");
            entity.Property(e => e.Remarks)
                .HasMaxLength(100)
                .HasColumnName("remarks");

            entity.HasOne(d => d.Cust).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.CustId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rating_Customer");

            entity.HasOne(d => d.Menu).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rating_Menu");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.CustId).HasName("PK_Customer");

            entity.ToTable("User");

            entity.Property(e => e.CustId)
                .ValueGeneratedNever()
                .HasColumnName("Cust_ID");
            entity.Property(e => e.CustAddress)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("Cust_Address");
            entity.Property(e => e.CustEmail)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Cust_email");
            entity.Property(e => e.CustName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Cust_Name");
            entity.Property(e => e.CustPassword)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("Cust_Password");
            entity.Property(e => e.CustPostCode)
                .IsRequired()
                .HasMaxLength(8)
                .HasColumnName("Cust_Post_code");
            entity.Property(e => e.CustTelNumber).HasColumnName("Cust_Tel_Number");
            entity.Property(e => e.CustUsername)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("Cust_Username");
            entity.Property(e => e.UserType).HasColumnName("User_type");

            entity.HasOne(d => d.UserTypeNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_UserType");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.UtypeId);

            entity.ToTable("UserType");

            entity.Property(e => e.UtypeId)
                .ValueGeneratedNever()
                .HasColumnName("UTypeID");
            entity.Property(e => e.UtName)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("UT_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
