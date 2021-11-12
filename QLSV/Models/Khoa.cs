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
        public string MaKhoa { get; set; }
        [Required(ErrorMessage = "Tên khoa không được bỏ trống")]
        public string TenKhoa { get; set; }
        public string DiaChi { get; set; }
        public int DienThoai { get; set; }
    }
}