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
        //public int ID { get; set; }
        [Required(ErrorMessage = "Mã lớp không được bỏ trống")]
        public string MaLop { get; set; }
        [Required(ErrorMessage = "Tên lớp không được bỏ trống")]
        public string TenLop { get; set; }
        public string MaKhoa { get; set; }
        [ForeignKey("MaKhoa")]
        public virtual Khoa Khoa { get; set; }
        public string MaHeDT { get; set; }
        [ForeignKey("MaHeDT")]
        public virtual HeDaotao HeDaotao { get; set; }
        public string MaKhoaHoc { get; set; }
        [ForeignKey("MaKhoaHoc")]
        public virtual KhoaHoc KhoaHoc { get; set; }
    }
}