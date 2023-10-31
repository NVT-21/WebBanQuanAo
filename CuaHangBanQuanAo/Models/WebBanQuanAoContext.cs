using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CuaHangBanQuanAo.Models;

public partial class WebBanQuanAoContext : DbContext
{
    public WebBanQuanAoContext()
    {
    }

    public WebBanQuanAoContext(DbContextOptions<WebBanQuanAoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-0QV26TOC;Initial Catalog=WebBanQuanAo;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK__KhachHan__2725CF1E651EF3C4");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKh)
                .HasMaxLength(10)
                .HasColumnName("MaKH");
            entity.Property(e => e.Anh).HasColumnType("ntext");
            entity.Property(e => e.MaTk).HasMaxLength(10);
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.TenKh)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TenKH");

            entity.HasOne(d => d.MaTkNavigation).WithMany(p => p.KhachHangs)
                .HasForeignKey(d => d.MaTk)
                .HasConstraintName("FK__KhachHang__MaTk__3C69FB99");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSp).HasName("PK__SanPham__2725087C5EEAC37C");

            entity.ToTable("SanPham");

            entity.Property(e => e.MaSp).HasMaxLength(10);
            entity.Property(e => e.Anh).HasColumnType("ntext");
            entity.Property(e => e.Mota)
                .HasMaxLength(100)
                .HasColumnName("mota");
            entity.Property(e => e.Loai)
               .HasMaxLength(100)
               .HasColumnName("Loai");
            entity.Property(e => e.TenSp)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.MaTk).HasName("PK__TaiKhoan__2725005076FBE1BB");

            entity.ToTable("TaiKhoan");

            entity.HasIndex(e => e.Tk, "UQ__TaiKhoan__3213E049D770CE59").IsUnique();

            entity.Property(e => e.MaTk).HasMaxLength(10);
            entity.Property(e => e.MatKhau)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Tk)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tk");
            entity.Property(e => e.VaiTro)
               .HasMaxLength(255)
               .IsUnicode(false)
               .HasColumnName("VaiTro");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
