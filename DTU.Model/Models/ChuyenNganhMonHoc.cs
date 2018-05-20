namespace DTU.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChuyenNganhMonHoc
    {
        public int ID { get; set; }

        [Display(Name = "Môn học")]
        public int? IDNamHoc { get; set; }

        [Display(Name = "Chuyên ngành")]
        public int? IDChuyenNganh { get; set; }

        public virtual ChuyenNganh ChuyenNganh { get; set; }

        public virtual MonHoc MonHoc { get; set; }
    }
}
