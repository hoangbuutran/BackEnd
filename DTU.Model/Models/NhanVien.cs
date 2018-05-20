namespace DTU.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NhanVien
    {
        [Display(Name = "Nhân viên")]
        [Key]
        public int IdNhanVien { get; set; }

        [Required]
        [Display(Name = "Tên nhân viên")]
        [StringLength(50)]
        public string TenNhanVien { get; set; }

        [Display(Name = "Ngày sinh")]
        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [Display(Name = "Điện thoại")]
        [Required]
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

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
