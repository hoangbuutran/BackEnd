namespace DTU.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using DTU.Model.Models;

    public partial class CoSoDuLieuDbContext : DbContext
    {
        public CoSoDuLieuDbContext()
            : base("name=CoSoDuLieuDbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<ChuyenNganh> ChuyenNganhs { get; set; }
        public virtual DbSet<ChuyenNganhMonHoc> ChuyenNganhMonHocs { get; set; }
        public virtual DbSet<CT_PhieuDangKy> CT_PhieuDangKys { get; set; }
        public virtual DbSet<HocKy> HocKys { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<NamHoc> NamHocs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhieuDangKy> PhieuDangKys { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChuyenNganh>()
                .HasMany(e => e.ChuyenNganhMonHoc)
                .WithOptional(e => e.ChuyenNganh)
                .HasForeignKey(e => e.IDChuyenNganh);

            modelBuilder.Entity<MonHoc>()
                .Property(e => e.MaMonHoc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MonHoc>()
                .HasMany(e => e.ChuyenNganhMonHoc)
                .WithOptional(e => e.MonHoc)
                .HasForeignKey(e => e.IDNamHoc);

            modelBuilder.Entity<NamHoc>()
                .Property(e => e.TenNamHoc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.DienThoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.MaSinhVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.CMND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.DienThoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
