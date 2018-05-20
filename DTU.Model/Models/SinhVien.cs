namespace DTU.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SinhVien
    {
        public SinhVien()
        {
            PhieuDangKy = new HashSet<PhieuDangKy>();
        }

        [Display(Name = "Mã sinh viên")]
        [Key]
        public int IdSinhVien { get; set; }

        [Display(Name = "Mã sinh viên")]
        [Required]
        [StringLength(500)]
        public string MaSinhVien { get; set; }

        [Display(Name = "Tên sinh viên")]
        [StringLength(500)]
        public string TenSinhVien { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime? NgaySinh { get; set; }

        [Display(Name = "Số CMND")]
        [StringLength(500)]
        public string CMND { get; set; }

        [Display(Name = "Điện thoại")]
        [StringLength(500)]
        public string DienThoai { get; set; }

        [Display(Name = "Địa chỉ")]
        [StringLength(900)]
        public string DiaChi { get; set; }
        [Display(Name = "Email")]
        [StringLength(500)]
        public string Email { get; set; }

        [Display(Name = "Trạng thái")]
        public bool? TrangThai { get; set; }

        [Display(Name = "Tài khoản")]
        public int? IdTaiKhoan { get; set; }

        [Display(Name = "Chuyên Ngành")]
        public int? IdChuyenNganh { get; set; }

        public virtual ChuyenNganh ChuyenNganh { get; set; }

        public virtual ICollection<PhieuDangKy> PhieuDangKy { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
