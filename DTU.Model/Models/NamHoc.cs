namespace DTU.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NamHoc
    {
        public NamHoc()
        {
            PhieuDangKy = new HashSet<PhieuDangKy>();
        }

        [Display(Name = "Năm học")]
        [Key]
        public int IdNamHoc { get; set; }

        [Display(Name = "Tên năm học")]
        [StringLength(500)]
        public string TenNamHoc { get; set; }

        [Display(Name = "Trạng thái")]
        public bool? TrangThai { get; set; }

        public virtual ICollection<PhieuDangKy> PhieuDangKy { get; set; }
    }
}
