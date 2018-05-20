namespace DTU.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_PhieuDangKy
    {
        [Key]
        public int IdCT_PhieuDangKy { get; set; }

        [Display(Name = "Phiếu đăng kí")]
        public int? IdPhieuDangKy { get; set; }

        [Display(Name = "Môn học")]
        public int? IdMonHoc { get; set; }

        public virtual MonHoc MonHoc { get; set; }

        public virtual PhieuDangKy PhieuDangKy { get; set; }
    }
}
