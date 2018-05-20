namespace DTU.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChuyenNganh
    {
        public ChuyenNganh()
        {
            SinhVien = new HashSet<SinhVien>();
            ChuyenNganhMonHoc = new HashSet<ChuyenNganhMonHoc>();
        }

        [Display(Name = "Chuyên ngành")]
        [Key]
        public int IDChuyenNganh { get; set; }

        [Display(Name = "Chuyên ngành")]
        [StringLength(500)]
        public string TenChuyenNganh { get; set; }

        public virtual ICollection<SinhVien> SinhVien { get; set; }

        public virtual ICollection<ChuyenNganhMonHoc> ChuyenNganhMonHoc { get; set; }
    }
}
