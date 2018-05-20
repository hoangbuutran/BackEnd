namespace DTU.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            NhanVien = new HashSet<NhanVien>();
            SinhVien = new HashSet<SinhVien>();
        }

        [Display(Name = "Tài khoản")]
        [Key]
        public int IdTaiKhoan { get; set; }

        [Display(Name = "UserName")]
        [StringLength(500)]
        public string UserName { get; set; }

        [Display(Name = "PassWord")]
        [StringLength(500)]
        public string Pass { get; set; }

        [Display(Name = "Trạng thái")]
        public bool? TrangThai { get; set; }

        [Display(Name = "Quyền")]
        public int? IdQuyen { get; set; }

        public virtual ICollection<NhanVien> NhanVien { get; set; }

        public virtual Quyen Quyen { get; set; }

        public virtual ICollection<SinhVien> SinhVien { get; set; }
    }
}
