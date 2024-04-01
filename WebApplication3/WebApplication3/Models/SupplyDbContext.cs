using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models;

public partial class SupplyDbContext : DbContext
{
    public SupplyDbContext()
    {
    }

    public SupplyDbContext(DbContextOptions<SupplyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomerDetail> CustomerDetails { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<ProductDetail> ProductDetails { get; set; }

    public virtual DbSet<RoleDetail> RoleDetails { get; set; }

    public virtual DbSet<StatusDetail> StatusDetails { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=USHYD4KSHIVAN7\\SQLEXPRESS;Database=SupplyDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerDetail>(entity =>
        {
            entity.HasKey(e => e.Cid);

            entity.Property(e => e.Cid)
                .ValueGeneratedNever()
                .HasColumnName("CId");
            entity.Property(e => e.Cemail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CEmail");
            entity.Property(e => e.Cname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CName");
            entity.Property(e => e.Cphone).HasColumnName("CPhone");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.Property(e => e.OrderId).ValueGeneratedNever();
            entity.Property(e => e.Cid).HasColumnName("CId");
            entity.Property(e => e.StatusId).HasColumnName("StatusId");
            entity.Property(e => e.ProductId).HasColumnName("ProductId");

            //   entity.HasOne(d => d.CidNavigation).WithMany(p => p.OrderDetails)
            //  .HasForeignKey(d => d.Cid)
            // .OnDelete(DeleteBehavior.ClientSetNull)
            // .HasConstraintName("FK_OrderDetails_CustomerDetails");
        });

        modelBuilder.Entity<ProductDetail>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.Property(e => e.ProductId).ValueGeneratedNever();
            entity.Property(e => e.ProductCost).HasColumnType("money");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RoleDetail>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.Property(e => e.RoleId).ValueGeneratedNever();
        });

        modelBuilder.Entity<StatusDetail>(entity =>
        {
            entity.HasKey(e => e.StatusId);

            entity.Property(e => e.StatusId).ValueGeneratedNever();
            entity.Property(e => e.StatusName).HasMaxLength(50);
        });
        modelBuilder.Entity<users>(entity =>
        {
            entity.HasKey(e => e.user_id);
            entity.Property(e => e.user_id).ValueGeneratedOnAdd();
            entity.Property(e => e.username).HasMaxLength(50);
            entity.Property(e => e.password).ValueGeneratedNever();
           
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
           


            //   entity.HasOne(d => d.Role).WithMany(p => p.UserDetails)
            // .HasForeignKey(d => d.RoleId)
            //.HasConstraintName("FK_UserDetails_RoleDetails");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
