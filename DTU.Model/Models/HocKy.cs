namespace DTU.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HocKy
    {
        public HocKy()
        {
            PhieuDangKy = new HashSet<PhieuDangKy>();
        }
        [Display(Name = "Học kỳ")]
        [Key]
        public int IdHocKy { get; set; }

        [Display(Name = "Tên học kỳ")]
        [StringLength(500)]
        public string TenHocKy { get; set; }

        public virtual ICollection<PhieuDangKy> PhieuDangKy { get; set; }
    }
}
