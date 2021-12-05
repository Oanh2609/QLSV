using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLSV.Models
{
    public class Khoa
    {
        [Key]
       // public int ID { get; set; }
        [Required(ErrorMessage = "Mã khoa không được bỏ trống")]
        [Display(Name = "Mã Khoa")]
        //để hiện view tiếng việt
        public string MaKhoa { get; set; }
        [Required(ErrorMessage = "Tên khoa không được bỏ trống")]
        [Display(Name = "Tên Khoa")]
        public string TenKhoa { get; set; }
        [Display(Name = "Địa Chỉ")]
        public string DiaChi { get; set; }
        //[Display(Name = "Điện thoại")]
       // public int DienThoai { get; set; }
    }
}