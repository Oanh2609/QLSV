using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLSV.Models
{
    public class Lop
    {
        [Key]
        
        [Required(ErrorMessage = "Mã lớp không được bỏ trống")]
        [Display(Name = "Mã Lớp")]
        public string MaLop { get; set; }
        [Required(ErrorMessage = "Tên lớp không được bỏ trống")]
        [Display(Name = "Tên Lớp")]
        public string TenLop { get; set; }
        [Display(Name = "Tên Khoa")]
        public string MaKhoa { get; set; }
        [ForeignKey("MaKhoa")]
        public virtual Khoa Khoa { get; set; }
        [Display(Name = "Tên Hệ ĐT")]
        public string MaHeDT { get; set; }
        [ForeignKey("MaHeDT")]
        public virtual HeDaotao HeDaotao { get; set; }
        [Display(Name = "Tên khoa")]
        public string MaKhoaHoc { get; set; }
        [ForeignKey("MaKhoaHoc")]
        public virtual KhoaHoc KhoaHoc { get; set; }
    }
}