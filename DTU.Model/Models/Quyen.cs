namespace DTU.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Quyen")]
    public partial class Quyen
    {
        public Quyen()
        {
            TaiKhoan = new HashSet<TaiKhoan>();
        }

        [Display(Name = "Quyền")]
        [Key]
        public int IdQuyen { get; set; }

        [Required(ErrorMessage = "Mời nhập tên quyền")]
        [Display(Name = "Tên quyền")]
        [StringLength(500)]
        public string TenQuyen { get; set; }

        [Display(Name = "Mô tả")]
        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }

        [Display(Name = "Trạng thái")]
        public bool? TrangThai { get; set; }

        public virtual ICollection<TaiKhoan> TaiKhoan { get; set; }
    }
}
