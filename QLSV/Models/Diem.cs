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
        public string MaSinhVien { get; set; }
        public string MaMonHoc { get; set; }
        [Required(ErrorMessage = "Học Kì không được bỏ trống")]
        public string HocKi { get; set; }
        [Required(ErrorMessage = "Điểm A không được bỏ trống")]
        public double DiemA { get; set; }
        [Required(ErrorMessage = "Điểm B không được bỏ trống")]
        public double DiemB { get; set; }
        [Required(ErrorMessage = "Điểm C không được bỏ trống")]
        public double DiemC { get; set; }
        public double DiemTB { get; set; }

        [ForeignKey("MaMonHoc")]
        public virtual MonHoc MonHoc { get; set; }
    }
}
