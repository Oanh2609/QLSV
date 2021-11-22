using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLSV.Models
{
    public class ViewIndex
    {
        [Display(Name = "Mã Sinh Viên")]
        public string Msv { get; set; }
        [Display(Name = "Họ Và Tên")]
        public string Hvt { get; set; }
        [Display(Name = "Mã Khoa")]
        public string MaKhoa { get; set; }
        [Display(Name = "Điểm TB")]
        public double DiemTB { get; set; }
        [Display(Name = "Lớp ")]
        public string Lop { get; set; }
    }
}