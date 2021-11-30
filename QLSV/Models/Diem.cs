using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLSV.Models
{
    public class Diem
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Mã Sinh Viên không được bỏ trống ")]
        [Display(Name ="Mã Sinh Viên")]
        public string MaSinhVien { get; set; }
        [Display(Name = "Mã Môn Học")]
        public string MaMonHoc { get; set; }
        [Required(ErrorMessage = "Học Kì không được bỏ trống")]
        [Display(Name = "Học Kì")]
        public string HocKi { get; set; }
        [Required(ErrorMessage = "Điểm A không được bỏ trống")]
        [Display(Name = "Điểm A")]
        public double DiemA { get; set; }
        [Required(ErrorMessage = "Điểm B không được bỏ trống")]
        [Display(Name = "Điểm B")]
        public double DiemB { get; set; }
        [Required(ErrorMessage = "Điểm C không được bỏ trống")]
        [Display(Name = "Điểm C")]
        public double DiemC { get; set; }
        [Display(Name = "Điểm Trung Bình")]
        public double DiemTB { get; set; }

        [ForeignKey("MaMonHoc")]
        public virtual MonHoc MonHoc { get; set; }
    }
}
