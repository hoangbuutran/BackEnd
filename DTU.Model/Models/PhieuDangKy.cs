namespace DTU.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PhieuDangKy
    {
        public PhieuDangKy()
        {
            CT_PhieuDangKy = new HashSet<CT_PhieuDangKy>();
        }
        [Display(Name = "Số Phiếu")]
        [Key]
        public int IdPhieuDangKy { get; set; }
        [Display(Name = "Mã Sinh viên")]
        public int? IdSinhVien { get; set; }

        [Display(Name = "Học kỳ")]
        public int? IdHocKy { get; set; }

        [Display(Name = "Năm học")]
        public int? IdNamHoc { get; set; }

        [Display(Name = "Tổng số tín chỉ")]
        public int? TongSoTinChi { get; set; }

        public virtual ICollection<CT_PhieuDangKy> CT_PhieuDangKy { get; set; }

        public virtual HocKy HocKy { get; set; }

        public virtual NamHoc NamHoc { get; set; }

        public virtual SinhVien SinhVien { get; set; }
    }
}
