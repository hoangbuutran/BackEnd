namespace DTU.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MonHoc
    {
        public MonHoc()
        {
            ChuyenNganhMonHoc = new HashSet<ChuyenNganhMonHoc>();
            CT_PhieuDangKy = new HashSet<CT_PhieuDangKy>();
        }
        [Display(Name = "Môn học")]
        [Key]
        public int IdMonHoc { get; set; }

        [Display(Name = "Mã môn học")]
        [Required]
        [StringLength(500)]
        public string MaMonHoc { get; set; }

        [Display(Name = "Tên môn học")]
        [StringLength(500)]
        [Required]
        public string TenMonHoc { get; set; }

        [Display(Name = "Số tín chỉ")]
        [Required]
        public int? SoChi { get; set; }

        [Display(Name = "Loại DVHT")]
        [StringLength(500)]
        public string LoaiDVHT { get; set; }

        [Display(Name = "Loại hình")]
        [StringLength(500)]
        public string LoaiHinh { get; set; }

        [Display(Name = "Môn học tiên quyết")]
        [StringLength(500)]
        public string MonTienQuyet { get; set; }

        [Display(Name = "Môn học song ngành")]
        [StringLength(500)]
        public string MonSongHanh { get; set; }

        [Display(Name = "Mô tả")]
        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }

        [Display(Name = "Trạng thái")]
        public bool? TrangThai { get; set; }


        [Display(Name = "Môn tự chọn ?")]
        public bool? TuChon { get; set; }

        [Display(Name = "Thuộc nhóm tự chọn")]
        public int? NhomTuChon { get; set; }

        public virtual ICollection<ChuyenNganhMonHoc> ChuyenNganhMonHoc { get; set; }

        public virtual ICollection<CT_PhieuDangKy> CT_PhieuDangKy { get; set; }
    }
}
