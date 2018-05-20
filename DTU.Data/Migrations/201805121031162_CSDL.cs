namespace DTU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CSDL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChuyenNganhMonHocs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDNamHoc = c.Int(),
                        IDChuyenNganh = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ChuyenNganhs", t => t.IDChuyenNganh)
                .ForeignKey("dbo.MonHocs", t => t.IDNamHoc)
                .Index(t => t.IDNamHoc)
                .Index(t => t.IDChuyenNganh);
            
            CreateTable(
                "dbo.ChuyenNganhs",
                c => new
                    {
                        IDChuyenNganh = c.Int(nullable: false, identity: true),
                        TenChuyenNganh = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.IDChuyenNganh);
            
            CreateTable(
                "dbo.SinhViens",
                c => new
                    {
                        IdSinhVien = c.Int(nullable: false, identity: true),
                        MaSinhVien = c.String(nullable: false, maxLength: 500, fixedLength: true, unicode: false),
                        TenSinhVien = c.String(maxLength: 500),
                        NgaySinh = c.DateTime(),
                        CMND = c.String(maxLength: 500, fixedLength: true, unicode: false),
                        DienThoai = c.String(maxLength: 500, fixedLength: true, unicode: false),
                        DiaChi = c.String(maxLength: 900),
                        Email = c.String(maxLength: 500, fixedLength: true, unicode: false),
                        TrangThai = c.Boolean(),
                        IdTaiKhoan = c.Int(),
                        IdChuyenNganh = c.Int(),
                    })
                .PrimaryKey(t => t.IdSinhVien)
                .ForeignKey("dbo.ChuyenNganhs", t => t.IdChuyenNganh)
                .ForeignKey("dbo.TaiKhoan", t => t.IdTaiKhoan)
                .Index(t => t.IdTaiKhoan)
                .Index(t => t.IdChuyenNganh);
            
            CreateTable(
                "dbo.PhieuDangKies",
                c => new
                    {
                        IdPhieuDangKy = c.Int(nullable: false, identity: true),
                        IdSinhVien = c.Int(),
                        IdHocKy = c.Int(),
                        IdNamHoc = c.Int(),
                        TongSoTinChi = c.Int(),
                    })
                .PrimaryKey(t => t.IdPhieuDangKy)
                .ForeignKey("dbo.HocKies", t => t.IdHocKy)
                .ForeignKey("dbo.NamHocs", t => t.IdNamHoc)
                .ForeignKey("dbo.SinhViens", t => t.IdSinhVien)
                .Index(t => t.IdSinhVien)
                .Index(t => t.IdHocKy)
                .Index(t => t.IdNamHoc);
            
            CreateTable(
                "dbo.CT_PhieuDangKy",
                c => new
                    {
                        IdCT_PhieuDangKy = c.Int(nullable: false, identity: true),
                        IdPhieuDangKy = c.Int(),
                        IdMonHoc = c.Int(),
                    })
                .PrimaryKey(t => t.IdCT_PhieuDangKy)
                .ForeignKey("dbo.MonHocs", t => t.IdMonHoc)
                .ForeignKey("dbo.PhieuDangKies", t => t.IdPhieuDangKy)
                .Index(t => t.IdPhieuDangKy)
                .Index(t => t.IdMonHoc);
            
            CreateTable(
                "dbo.MonHocs",
                c => new
                    {
                        IdMonHoc = c.Int(nullable: false, identity: true),
                        MaMonHoc = c.String(nullable: false, maxLength: 500, fixedLength: true, unicode: false),
                        TenMonHoc = c.String(nullable: false, maxLength: 500),
                        SoChi = c.Int(nullable: false),
                        LoaiDVHT = c.String(maxLength: 500),
                        LoaiHinh = c.String(maxLength: 500),
                        MonTienQuyet = c.String(maxLength: 500),
                        MonSongHanh = c.String(maxLength: 500),
                        MoTa = c.String(storeType: "ntext"),
                        TrangThai = c.Boolean(),
                        TuChon = c.Boolean(),
                        NhomTuChon = c.Int(),
                    })
                .PrimaryKey(t => t.IdMonHoc);
            
            CreateTable(
                "dbo.HocKies",
                c => new
                    {
                        IdHocKy = c.Int(nullable: false, identity: true),
                        TenHocKy = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.IdHocKy);
            
            CreateTable(
                "dbo.NamHocs",
                c => new
                    {
                        IdNamHoc = c.Int(nullable: false, identity: true),
                        TenNamHoc = c.String(maxLength: 500, fixedLength: true, unicode: false),
                        TrangThai = c.Boolean(),
                    })
                .PrimaryKey(t => t.IdNamHoc);
            
            CreateTable(
                "dbo.TaiKhoan",
                c => new
                    {
                        IdTaiKhoan = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 500),
                        Pass = c.String(maxLength: 500),
                        TrangThai = c.Boolean(),
                        IdQuyen = c.Int(),
                    })
                .PrimaryKey(t => t.IdTaiKhoan)
                .ForeignKey("dbo.Quyen", t => t.IdQuyen)
                .Index(t => t.IdQuyen);
            
            CreateTable(
                "dbo.NhanViens",
                c => new
                    {
                        IdNhanVien = c.Int(nullable: false, identity: true),
                        TenNhanVien = c.String(nullable: false, maxLength: 50),
                        NgaySinh = c.DateTime(storeType: "date"),
                        DienThoai = c.String(nullable: false, maxLength: 500, fixedLength: true, unicode: false),
                        DiaChi = c.String(maxLength: 900),
                        Email = c.String(maxLength: 500, fixedLength: true, unicode: false),
                        TrangThai = c.Boolean(),
                        IdTaiKhoan = c.Int(),
                    })
                .PrimaryKey(t => t.IdNhanVien)
                .ForeignKey("dbo.TaiKhoan", t => t.IdTaiKhoan)
                .Index(t => t.IdTaiKhoan);
            
            CreateTable(
                "dbo.Quyen",
                c => new
                    {
                        IdQuyen = c.Int(nullable: false, identity: true),
                        TenQuyen = c.String(nullable: false, maxLength: 500),
                        MoTa = c.String(storeType: "ntext"),
                        TrangThai = c.Boolean(),
                    })
                .PrimaryKey(t => t.IdQuyen);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SinhViens", "IdTaiKhoan", "dbo.TaiKhoan");
            DropForeignKey("dbo.TaiKhoan", "IdQuyen", "dbo.Quyen");
            DropForeignKey("dbo.NhanViens", "IdTaiKhoan", "dbo.TaiKhoan");
            DropForeignKey("dbo.PhieuDangKies", "IdSinhVien", "dbo.SinhViens");
            DropForeignKey("dbo.PhieuDangKies", "IdNamHoc", "dbo.NamHocs");
            DropForeignKey("dbo.PhieuDangKies", "IdHocKy", "dbo.HocKies");
            DropForeignKey("dbo.CT_PhieuDangKy", "IdPhieuDangKy", "dbo.PhieuDangKies");
            DropForeignKey("dbo.CT_PhieuDangKy", "IdMonHoc", "dbo.MonHocs");
            DropForeignKey("dbo.ChuyenNganhMonHocs", "IDNamHoc", "dbo.MonHocs");
            DropForeignKey("dbo.SinhViens", "IdChuyenNganh", "dbo.ChuyenNganhs");
            DropForeignKey("dbo.ChuyenNganhMonHocs", "IDChuyenNganh", "dbo.ChuyenNganhs");
            DropIndex("dbo.NhanViens", new[] { "IdTaiKhoan" });
            DropIndex("dbo.TaiKhoan", new[] { "IdQuyen" });
            DropIndex("dbo.CT_PhieuDangKy", new[] { "IdMonHoc" });
            DropIndex("dbo.CT_PhieuDangKy", new[] { "IdPhieuDangKy" });
            DropIndex("dbo.PhieuDangKies", new[] { "IdNamHoc" });
            DropIndex("dbo.PhieuDangKies", new[] { "IdHocKy" });
            DropIndex("dbo.PhieuDangKies", new[] { "IdSinhVien" });
            DropIndex("dbo.SinhViens", new[] { "IdChuyenNganh" });
            DropIndex("dbo.SinhViens", new[] { "IdTaiKhoan" });
            DropIndex("dbo.ChuyenNganhMonHocs", new[] { "IDChuyenNganh" });
            DropIndex("dbo.ChuyenNganhMonHocs", new[] { "IDNamHoc" });
            DropTable("dbo.Quyen");
            DropTable("dbo.NhanViens");
            DropTable("dbo.TaiKhoan");
            DropTable("dbo.NamHocs");
            DropTable("dbo.HocKies");
            DropTable("dbo.MonHocs");
            DropTable("dbo.CT_PhieuDangKy");
            DropTable("dbo.PhieuDangKies");
            DropTable("dbo.SinhViens");
            DropTable("dbo.ChuyenNganhs");
            DropTable("dbo.ChuyenNganhMonHocs");
        }
    }
}
